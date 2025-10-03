using Eventos.Control;
using Eventos.DAO;
using Eventos.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eventos.Model.Orcamento;

namespace Eventos.View
{
    public partial class frmAdicionarAgendamentoView : Form
    {
        String mensagem = "";

        public frmAdicionarAgendamentoView()
        {

            InitializeComponent();
        }
    }
}