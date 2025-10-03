using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.DAO;
using Eventos.Model;


namespace Eventos.Control
{
    public class AgendamentoControl
    {
        private AgendamentoDAO AgendamentoDAO = new AgendamentoDAO();

        public DataTable GetAllAgendamentos()
        {
            return AgendamentoDAO.GetAll();
        }

        public DataTable GetAgendamentoAsDataTable(string tipo_evento)
        {
            return AgendamentoDAO.GetAgendamentoAsDataTable(tipo_evento);
        }

        public Agendamento GetAgendamentoByAgendamento(string tipo_evento)
        {
            return AgendamentoDAO.GetByAgendamento(tipo_evento);
        }

        public void AddAgendamento(Agendamento agendamento)
        {
            AgendamentoDAO.Add(agendamento);
        }

        public void UpdateAgendamento(Agendamento agendamento)
        {
            AgendamentoDAO.Update(agendamento);
        }

        public void DeleteAgendamento(Agendamento Agendamento)
        {
            AgendamentoDAO.Delete(Agendamento);
        }
    }
}
