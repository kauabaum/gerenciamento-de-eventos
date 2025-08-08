using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eventos.Model
{
    public class Orcamento
    {
        public int IdOrcamento { get; set; }
        public string TipoEvento { get; set; }
        public double Total { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Aprovacao { get; set; }
        public string LocalEvento { get; set; }
        public DateTime DataEvento { get; set; }
        public string HoraEvento { get; set; }
        public int IdTema { get; set; }
        public string TemaNome { get; set; }
        public string Validade { get; set; }
    }
}