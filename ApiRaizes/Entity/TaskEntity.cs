namespace ApiRaizes.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
    }
}