using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class StockMovementGetAllResponse
    {
        public IEnumerable<StockMovementEntity> Data { get; set; }
    }
}
