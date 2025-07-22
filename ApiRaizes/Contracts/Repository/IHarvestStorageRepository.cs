using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IHarvestStorageRepository
    {
        Task<IEnumerable<HarvestStorageEntity>> GetAll();

        Task<HarvestStorageEntity> GetById(int id);

        Task Insert(HarvestStorageInsertDTO harvestStorage);

        Task Delete(int id);

        Task Update(HarvestStorageEntity harvestStorage);
    }
}
