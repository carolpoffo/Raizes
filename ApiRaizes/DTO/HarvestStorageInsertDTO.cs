namespace ApiRaizes.DTO
{
    public enum StatusStock
    {
        Disponivel,
        Reservado,
        Vendido
    }
    public class HarvestStorageInsertDTO
    {
        public int ColheitaId { get; set; }
        public decimal QuantidadeDisponivel { get; set; }
        public string LocalArmazenamento { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public StatusStock Status { get; set; }

    }
}
