using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class CityGetAllResponse
    {
        public IEnumerable<CityEntity> Data { get; set; }
    }
}
