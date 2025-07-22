namespace ApiRaizes.DTO
{
    public class RawMaterialStockInsertDTO
    {
        public int PropriedadeId { get; set; }
        public int InsumoId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}