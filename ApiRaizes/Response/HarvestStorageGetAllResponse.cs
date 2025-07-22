using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class HarvestStorageGetAllResponse
    {
        public IEnumerable<HarvestStorageEntity> Data { get; set; }
    }
}
