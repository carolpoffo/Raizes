namespace ApiRaizes.DTO
{
    public class RawMaterialInsertDTO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime DataDeValidade { get; set; }

        public string Descricao { get; set; }
        public int FornecedorId { get; set; }
    }
}