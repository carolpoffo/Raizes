using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class SupplierGetAllResponse
    {
        public IEnumerable<SupplierEntity> Data { get; set; }
    }
}
