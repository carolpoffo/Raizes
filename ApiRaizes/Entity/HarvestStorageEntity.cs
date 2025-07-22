namespace ApiRaizes.Entity
{
    public enum StatusStock2
    {
        Disponivel,
        Reservado,
        Vendido
    }
    public class HarvestStorageEntity
    {
        public int Id { get; set; }
        public int ColheitaId { get; set; }
        public decimal QuantidadeDisponivel { get; set; }
        public string LocalArmazenamento { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public StatusStock2 Status { get; set; }
    }
}
