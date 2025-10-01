using Eventos.DAO;
using Eventos.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Eventos.Controller
{
    public class ItensOrcamentoControl
    {
        private ItensOrcamentoDAO itensOrcamentoDAO;
        private ProdutoDAO produtoDAO;  // Para consultar estoque do produto

        public ItensOrcamentoControl()
        {
            itensOrcamentoDAO = new ItensOrcamentoDAO();
            produtoDAO = new ProdutoDAO();
        }

        // Atualizar um item do orçamento
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

        // Deletar um item do orçamento
        public void DeletarItemDoOrcamento(int idItens)
        {
            itensOrcamentoDAO.Delete(idItens);
        }

        // Buscar todos os itens de um orçamento específico
        public List<ItemOrcamento> BuscarItensPorOrcamento(int idOrcamento)
        {
            return itensOrcamentoDAO.GetByOrcamentoId(idOrcamento);
        }

        // Buscar todos os itens de orçamento (opcional)
        public DataTable BuscarTodosItens()
        {
            return itensOrcamentoDAO.GetAll();
        }
    }
}
