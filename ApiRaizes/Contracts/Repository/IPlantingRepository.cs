using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IPlantingRepository
    {
        Task<IEnumerable<PlantingEntity>> GetAll();

        Task<PlantingEntity> GetById(int id);

        Task Insert(PlantingInsertDTO planting);

        Task Delete(int id);

        Task Update(PlantingEntity planting);
    }
}