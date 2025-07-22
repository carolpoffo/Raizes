using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class SoilTypeGetAllResponse
    {
        public IEnumerable<SoilTypeEntity> Data { get; set; }
    }
}
