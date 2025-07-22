namespace ApiRaizes.DTO
{
    public class TaskInsertDTO
    {
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
    }
}