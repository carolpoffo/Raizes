using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IHarvestRepository
    {
        Task<IEnumerable<HarvestEntity>> GetAll();

        Task<HarvestEntity> GetById(int id);

        Task Insert(HarvestInsertDTO harvest);

        Task Delete(int id);

        Task Update(HarvestEntity harvest);
    }
}
