namespace ApiRaizes.DTO
{
    public class StockMovementInsertDTO
    {
        public enum MovementType
        {
            Venda,
            Transferencia,
            Ajuste
        }
        public int ArmazenamentoId { get; set; }
        public MovementType TipoMovimento { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string Observacoes { get; set; }
    }
}