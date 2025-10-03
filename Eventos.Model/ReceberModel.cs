using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eventos.Model
{
    public class Receber
    {
        public int IdReceber { get; set; }
        public int IdAgendamento { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorTotal { get; set; }
    }
}