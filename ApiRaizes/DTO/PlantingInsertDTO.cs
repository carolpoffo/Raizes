namespace ApiRaizes.DTO
{
    public class PlantingInsertDTO
    {
        public int EspecieId { get; set; }
        public int PropriedadeId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal AreaPlantada { get; set; }
        public int Mudas { get; set; }
        public string Descricao { get; set; }
        public int UnidadeMedidaId { get; set; }
    }
}