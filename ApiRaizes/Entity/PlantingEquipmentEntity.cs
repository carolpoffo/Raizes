namespace ApiRaizes.Entity
{
    public class PlantingEquipmentEntity
    {
        public int Id { get; set; }
        public int PlantioId { get; set; }
        public int EquipamentoId { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAplicacao { get; set; }
    }
}