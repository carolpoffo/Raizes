namespace ApiRaizes.Entity
{
    public class EventEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Local { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Descricao { get; set; }
    }
}