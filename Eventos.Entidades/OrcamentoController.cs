using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.DAO;
using Eventos.Model;


namespace Eventos.Controller
{
    public class OrcamentoController
    {
        private OrcamentoDAO OrcamentoDAO = new OrcamentoDAO();

        public DataTable GetAllOrcamentos()
        {
            return OrcamentoDAO.GetAll();
        }

        public DataTable GetOrcamentoAsDataTable(string tipo_evento)
        {
            return OrcamentoDAO.GetOrcamentoAsDataTable(tipo_evento);
        }

        public Orcamento GetOrcamentoByOrcamento(string nome)
        {
            return OrcamentoDAO.GetByOrcamento(nome);
        }

        public void AddOrcamento(Orcamento orcamento)
        {
            OrcamentoDAO.Add(orcamento);
        }

        public void UpdateOrcamento(Orcamento orcamento)
        {
            OrcamentoDAO.Update(orcamento);
        }

        public void DeleteOrcamento(Orcamento Orcamento)
        {
            OrcamentoDAO.Delete(Orcamento);
        }
    }
}
