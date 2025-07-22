using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class PlantingGetAllResponse
    {
        public IEnumerable<PlantingEntity> Data { get; set; }
    }
}