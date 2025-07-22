using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IHarvestStorageService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<HarvestStorageGetAllResponse> GetAll();
        Task<HarvestStorageEntity> GetById(int id);
        Task<MessageAllResponse> Post(HarvestStorageInsertDTO harvestStorage);
        Task<MessageAllResponse> Update(HarvestStorageEntity harvestStorage);
    }
}