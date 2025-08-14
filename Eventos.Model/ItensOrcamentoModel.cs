namespace Eventos.Model
{
    public class ItemOrcamento
    {
        public int IdItens { get; set; }          // ID do item no orçamento
        public int Quantidade { get; set; }       // Quantidade do produto no orçamento
        public double Subtotal { get; set; }      // Subtotal do item (quantidade * valor)
        public int IdOrcamento { get; set; }      // ID do orçamento ao qual o item pertence
        public int IdProduto { get; set; }        // ID do produto que foi adicionado ao orçamento

        // Propriedade adicional para facilitar o acesso aos dados
        public Produto Produto { get; set; }      // Relacionamento com o modelo Produto, se necessário
        public Orcamento Orcamento { get; set; }  // Relacionamento com o modelo Orcamento, se necessário
    }
}
