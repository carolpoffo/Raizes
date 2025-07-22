using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class EquipmentGetAllResponse
    {
        public IEnumerable<EquipmentEntity> Data { get; set; }
    }
}
