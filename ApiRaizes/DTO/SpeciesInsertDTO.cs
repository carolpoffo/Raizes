namespace ApiRaizes.DTO
{
    public class SpeciesInsertDTO
    {
        public string NomeComum { get; set; }
        public string NomeCientifico { get; set; }
        public string Variedade { get; set; }

        public string EpocaDePlantio { get; set; }
        public string EpocaDeColheita { get; set; }

        public int TempoDeColheita { get; set; }
        public int TipoSoloIdealId { get; set; }
        public decimal IdealUmidadeMin { get; set; }
        public decimal IdealUmidadeMax { get; set; }
        public string Caracteristicas { get; set; }
        public List<string> PlantingSeasonList
        {
            get
            {
                return EpocaDePlantio?.Split(',')
                                       .Select(x => x.Trim())
                                       .Where(x => !string.IsNullOrWhiteSpace(x))
                                       .ToList() ?? new List<string>();
            }
        }

        public List<string> HarvestSeasonList
        {
            get
            {
                return EpocaDeColheita?.Split(',')
                                        .Select(x => x.Trim())
                                        .Where(x => !string.IsNullOrWhiteSpace(x))
                                        .ToList() ?? new List<string>();
            }
        }

    }
}