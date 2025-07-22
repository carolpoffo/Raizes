namespace ApiRaizes.Entity
{
    public class RawMaterialEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime DataDeValidade { get; set; }

        public string Descricao { get; set; }
        public int FornecedorId { get; set; }

    }

}