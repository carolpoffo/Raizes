using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class RawMaterialStockGetAllResponse
    {
        public IEnumerable<RawMaterialStockEntity> Data { get; set; }
    }
}