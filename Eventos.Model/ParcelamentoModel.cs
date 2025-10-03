using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eventos.Model
{
    public class Parcelamento
    {
        public int IdParcelamento { get; set; }
        public int IdAgendamento { get; set; }
        public string TipoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public DateTime Vencimento { get; set; }
    }


}