using Eventos.DAO;
using Eventos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Eventos.Controller
{
    public class ItensOrcamentoControl
    {
        private ItensOrcamentoDAO itensOrcamentoDAO;

        public ItensOrcamentoControl()
        {
            // Inicializa o DAO que fará as operações no banco
            itensOrcamentoDAO = new ItensOrcamentoDAO();
        }

        // Adicionar um item ao orçamento
        public void AdicionarItemAoOrcamento(int idOrcamento, int idProduto, int quantidade, double valorProduto)
        {
            // Calcular o subtotal
            double subtotal = quantidade * valorProduto;

            // Criar o item do orçamento
            ItemOrcamento item = new ItemOrcamento
            {
                Quantidade = quantidade,
                Subtotal = subtotal,
                IdOrcamento = idOrcamento,
                IdProduto = idProduto
            };

            // Adicionar o item no banco de dados
            itensOrcamentoDAO.Add(item);
        }

        // Atualizar um item do orçamento
        public void AtualizarItemNoOrcamento(int idItens, int quantidade, double subtotal)
        {
            // Criar o item de orçamento para atualização
            ItemOrcamento item = new ItemOrcamento
            {
                IdItens = idItens,
                Quantidade = quantidade,
                Subtotal = subtotal
            };

            // Atualizar o item no banco de dados
            itensOrcamentoDAO.Update(item);
        }

        // Deletar um item do orçamento
        public void DeletarItemDoOrcamento(int idItens)
        {
            // Excluir o item do banco de dados
            itensOrcamentoDAO.Delete(idItens);
        }

        // Buscar todos os itens de um orçamento específico
        public List<ItemOrcamento> BuscarItensPorOrcamento(int idOrcamento)
        {
            // Buscar itens do orçamento no banco de dados
            List<ItemOrcamento> itens = itensOrcamentoDAO.GetByOrcamentoId(idOrcamento);
            return itens;
        }

        // Buscar todos os itens de orçamento (opcional)
        public DataTable BuscarTodosItens()
        {
            // Obter todos os itens no banco de dados
            return itensOrcamentoDAO.GetAll();
        }

    }
}
