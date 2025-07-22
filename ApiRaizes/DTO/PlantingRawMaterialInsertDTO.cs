namespace ApiRaizes.DTO
{
    public class PlantingRawMaterialInsertDTO
    {
        public int PlantioId { get; set; }
        public int InsumoId { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAplicacao { get; set; }
    }
}