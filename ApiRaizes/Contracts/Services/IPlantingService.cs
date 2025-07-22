using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IPlantingService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<PlantingGetAllResponse> GetAll();
        Task<PlantingEntity> GetById(int id);
        Task<MessageAllResponse> Post(PlantingInsertDTO planting);
        Task<MessageAllResponse> Update(PlantingEntity planting);
    }
}