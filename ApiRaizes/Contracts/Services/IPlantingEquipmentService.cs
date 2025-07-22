using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IPlantingEquipmentService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<PlantingEquipmentGetAllResponse> GetAll();
        Task<PlantingEquipmentEntity> GetById(int id);
        Task<MessageAllResponse> Post(PlantingEquipmentInsertDTO plantingEquipment);
        Task<MessageAllResponse> Update(PlantingEquipmentEntity plantingEquipment);
    }
}