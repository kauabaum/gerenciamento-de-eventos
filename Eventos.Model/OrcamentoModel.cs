using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eventos.Model
{
    public class Orcamento
    {
        public int IdOrcamento { get; set; }
        public string TipoEvento { get; set; }
        public string NomeCliente { get; set; }
        public double Total { get; set; }
        public DateTime DataEmissao { get; set; }

        // pega o enum do status
        public enum StatusAprovacao
        {
            Aprovado,
            Aguardando,
            Vencido,
            Reprovado,
            Cancelado
        }
        public StatusAprovacao Aprovacao { get; set; }
        public string LocalEvento { get; set; }
        public DateTime DataEvento { get; set; }
        public string HoraEvento { get; set; }
        public string Tema { get; set; }
        public string Validade { get; set; }

        public static implicit operator DataTable(Orcamento v)
        {
            throw new NotImplementedException();
        }
    }
}