using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class SoilHistoricGetAllResponse
    {
        public IEnumerable<SoilHistoricEntity> Data { get; set; }
    }
}