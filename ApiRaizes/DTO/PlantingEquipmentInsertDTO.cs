namespace ApiRaizes.DTO
{
    public class PlantingEquipmentInsertDTO
    {
        public int PlantioId { get; set; }
        public int EquipamentoId { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAplicacao { get; set; }
    }
}