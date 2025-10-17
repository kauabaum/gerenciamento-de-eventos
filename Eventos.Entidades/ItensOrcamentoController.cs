using Eventos.DAO;
using Eventos.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Eventos.Controller
{
    public class ItensOrcamentoController
    {
        private ItensOrcamentoDAO itensOrcamentoDAO;
        private ProdutoDAO produtoDAO;  //consulta o estoque

        public ItensOrcamentoController()
        {
            itensOrcamentoDAO = new ItensOrcamentoDAO();
            produtoDAO = new ProdutoDAO();
        }

        public void AtualizarItemNoOrcamento(int idItens, int quantidade, double subtotal)
        {
            ItemOrcamento item = new ItemOrcamento
            {
                IdItens = idItens,
                Quantidade = quantidade,
                Subtotal = subtotal
            };

            itensOrcamentoDAO.Update(item);
        }

        public void DeletarItemDoOrcamento(int idItens)
        {
            itensOrcamentoDAO.Delete(idItens);
        }

        public List<ItemOrcamento> BuscarItensPorOrcamento(int idOrcamento)
        {
            return itensOrcamentoDAO.GetByOrcamentoId(idOrcamento);
        }

        public DataTable BuscarTodosItens()
        {
            return itensOrcamentoDAO.GetAll();
        }
    }
}
