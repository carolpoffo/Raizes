namespace ApiRaizes.DTO
{
    public class EquipmentInsertDTO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int FornecedorId { get; set; }
        public DateTime DataCompra { get; set; }
    }
}