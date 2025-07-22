namespace ApiRaizes.Entity
{
    public class SoilHistoricEntity
    {
        public int Id { get; set; }
        public int TipoSoloId { get; set; }
        public DateTime DataLeitura { get; set; }
        public decimal Umidade { get; set; }
        public string Observacoes { get; set; }
        public int PropriedadeId { get; set; }
    }
}