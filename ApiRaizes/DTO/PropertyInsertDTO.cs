namespace ApiRaizes.DTO
{
    public enum StatusCulture
    {
        Monocultura,
        Policultura
    }
    public class PropertyInsertDTO
    {
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        public int UsuarioId { get; set; }
        public decimal Tamanho { get; set; }
        public StatusCulture Cultura { get; set; }
        public int UnidadeMedidaId { get; set; }
    }
}
