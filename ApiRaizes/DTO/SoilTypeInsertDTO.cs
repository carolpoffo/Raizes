namespace ApiRaizes.DTO
{
    public class SoilTypeInsertDTO
    {
        public enum TextureType
        {
            Arenoso,
            Argiloso,
            Medio,
            Siltoso
        }

        public string Nome { get; set; }
        public TextureType Textura { get; set; }
        public string Descricao { get; set; }
    }
}