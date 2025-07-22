using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IPlantingRawMaterialService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<PlantingRawMaterialGetAllResponse> GetAll();
        Task<PlantingRawMaterialEntity> GetById(int id);
        Task<MessageAllResponse> Post(PlantingRawMaterialInsertDTO plantingRawMaterial);
        Task<MessageAllResponse> Update(PlantingRawMaterialEntity plantingRawMaterial);
    }
}