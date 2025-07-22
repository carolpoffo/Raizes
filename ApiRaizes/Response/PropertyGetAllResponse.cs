using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class PropertyGetAllResponse
    {
        public IEnumerable<PropertyEntity> Data { get; set; }
    }
}