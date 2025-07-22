namespace ApiRaizes.Entity
{
    public class PlantingRawMaterialEntity
    {
        public int Id { get; set; }
        public int PlantioId { get; set; }
        public int InsumoId { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAplicacao { get; set; }

    }
}