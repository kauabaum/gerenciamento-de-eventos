namespace Eventos.Model
{
    public class ItemOrcamento
    {
        public int IdItens { get; set; }      
        public int Quantidade { get; set; }      
        public double Subtotal { get; set; }      
        public int IdOrcamento { get; set; }      
        public int IdProduto { get; set; }        

        public Produto Produto { get; set; }     
        public Orcamento Orcamento { get; set; }  
    }
}
