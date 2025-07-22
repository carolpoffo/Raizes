namespace ApiRaizes.Entity
{
    public enum StatusCulture2
    {
        Monocultura,
        Policultura
    }
    public class PropertyEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        public int UsuarioId { get; set; }
        public decimal Tamanho { get; set; }
        public StatusCulture2 Cultura { get; set; }
        public int UnidadeMedidaId { get; set; }
    }
}