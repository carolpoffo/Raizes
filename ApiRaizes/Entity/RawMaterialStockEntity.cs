namespace ApiRaizes.Entity
{
    public class RawMaterialStockEntity
    {
        public int Id { get; set; }
        public int PropriedadeId { get; set; }
        public int InsumoId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}