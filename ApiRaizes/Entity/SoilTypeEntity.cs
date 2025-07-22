namespace ApiRaizes.Entity
{
    public class SoilTypeEntity
    {
        public enum TextureType2
        {
            Arenoso,
            Argiloso,
            Medio,
            Siltoso
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public TextureType2 Textura { get; set; }
        public string Descricao { get; set; }
    }
}