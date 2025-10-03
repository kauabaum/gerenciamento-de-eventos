using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eventos.Model
{
    public class Agendamento
    {
        public int IdAgendamento { get; set; }
        public string TipoEvento { get; set; }
        public string NomeCliente { get; set; }
        public int IdCliente { get; set; }
        public double Total { get; set; }
        public DateTime DataEmissao { get; set; }
        public string LocalEvento { get; set; }
        public DateTime DataEvento { get; set; }
        public string HoraEvento { get; set; }
        public string Tema { get; set; }

    }

}