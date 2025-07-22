using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IHarvestService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<HarvestGetAllResponse> GetAll();
        Task<HarvestEntity> GetById(int id);
        Task<MessageAllResponse> Post(HarvestInsertDTO harvest);
        Task<MessageAllResponse> Update(HarvestEntity harvest);
    }
}