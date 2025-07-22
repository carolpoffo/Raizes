using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class SaleGetAllResponse
    {
        public IEnumerable<SaleEntity> Data { get; set; }
    }
}
