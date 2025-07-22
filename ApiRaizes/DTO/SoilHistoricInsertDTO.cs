namespace ApiRaizes.DTO
{
    public class SoilHistoricInsertDTO
    {
        public int TipoSoloId { get; set; }
        public DateTime DataLeitura { get; set; }
        public decimal Umidade { get; set; }
        public string Observacoes { get; set; }
        public int PropriedadeId { get; set; }
    }
}