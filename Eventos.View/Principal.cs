using Eventos.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Eventos.View
{
    public partial class frmPrincipal : Form
    {
        private AgendamentoDAO agendamentoDAO;
        private ParcelamentoDAO parcelamentoDAO;

        private Size formOriginalSize;
        private Dictionary<Control, Rectangle> controlesOriginais = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> fontesOriginais = new Dictionary<Control, float>();
        private bool formatoBrasileiro = true;

        private bool tamanhoBaseDefinido = false;
        private bool ignorarResize = false;

        public frmPrincipal()
        {
            InitializeComponent();
            agendamentoDAO = new AgendamentoDAO();
            parcelamentoDAO = new ParcelamentoDAO();

            SalvarControlesOriginais(this);

            this.Resize += Form_Resize;
            this.Load += frmPrincipal_Load;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // Captura o tamanho real da janela
            if (!tamanhoBaseDefinido)
            {
                formOriginalSize = this.ClientSize;
                tamanhoBaseDefinido = true;
            }

            // Carrega dados
            CarregarAgendamentosSemana();
            CarregarParcelasPendentes();

            Timer timerRelogio = new Timer();
            timerRelogio.Interval = 1000; // 1 segundo
            timerRelogio.Tick += TimerRelogio_Tick;
            timerRelogio.Start();
            // Maximiza após carregar o layout base
            this.WindowState = FormWindowState.Maximized;
        }

        private void SalvarControlesOriginais(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                controlesOriginais[c] = c.Bounds;
                fontesOriginais[c] = c.Font.Size;

                if (c.HasChildren)
                    SalvarControlesOriginais(c);
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (!tamanhoBaseDefinido || formOriginalSize.Width == 0 || formOriginalSize.Height == 0)
                return;

            // Ignora se estiver minimizado
            if (this.WindowState == FormWindowState.Minimized)
            {
                ignorarResize = true;
                return;
            }

            // Se voltou do minimizado, aplica apenas uma vez
            if (ignorarResize)
            {
                ignorarResize = false;
                RedimensionarControles();
                return;
            }

            // Redimensionamento normal
            RedimensionarControles();
        }

        private void RedimensionarControles()
        {
            float scaleX = (float)this.ClientSize.Width / formOriginalSize.Width;
            float scaleY = (float)this.ClientSize.Height / formOriginalSize.Height;

            foreach (var kvp in controlesOriginais)
            {
                Control c = kvp.Key;
                Rectangle r = kvp.Value;

                c.Left = (int)(r.Left * scaleX);
                c.Top = (int)(r.Top * scaleY);
                c.Width = (int)(r.Width * scaleX);
                c.Height = (int)(r.Height * scaleY);

                if (fontesOriginais.ContainsKey(c))
                {
                    float originalFont = fontesOriginais[c];
                    float newFontSize = originalFont * Math.Min(scaleX, scaleY);
                    c.Font = new Font(c.Font.FontFamily, newFontSize, c.Font.Style);
                }
            }
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmClienteView().ShowDialog();
        }

        private void temasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTemaView().ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCategoriaView().ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void produtosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new frmProdutoView().ShowDialog();
        }

        private void OrcamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmOrcamentoView().ShowDialog();
        }

        private void AgendamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAgendamentoView().ShowDialog();
        }

        private void financeiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmFinanceiroView().ShowDialog();
        }

        private void CarregarAgendamentosSemana()
        {
            DataTable dt = agendamentoDAO.GetAgendamentosDaSemana();
            grdAgenda.DataSource = dt;
            grdAgenda.Columns["Id_Agendamento"].Visible = false;
            grdAgenda.Columns["Id_Cliente"].Visible = false;
            grdAgenda.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CarregarParcelasPendentes()
        {
            DataTable dt = parcelamentoDAO.GetParcelasPendentes();
            grdPendente.DataSource = null;
            grdPendente.DataSource = dt;
            grdPendente.Columns["Id_Receber"].Visible = false;
            grdPendente.Columns["Id_Parcela"].Visible = false;
            grdPendente.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Recarregar_Click(object sender, EventArgs e)
        {
            CarregarParcelasPendentes();
            CarregarAgendamentosSemana();
        }
        private void TimerRelogio_Tick(object sender, EventArgs e)
        {
            DateTime agora = DateTime.Now;

            // Hora atual: HH:mm:ss (24h)
            lblHora.Text = agora.ToString("HH:mm:ss");

            // Data e hora completa dependendo do formato
            if (formatoBrasileiro)
            {
                lblDataHora.Text = agora.ToString("dd/MM/yyyy"); // dd/MM/yyyy
            }
            else
            {
                lblDataHora.Text = agora.ToString("MM/dd/yyyy"); // MM/dd/yyyy
            }
        }
    }
}
