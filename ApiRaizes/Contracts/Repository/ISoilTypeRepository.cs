using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ISoilTypeRepository
    {
        Task<IEnumerable<SoilTypeEntity>> GetAll();

        Task<SoilTypeEntity> GetById(int id);

        Task Insert(SoilTypeInsertDTO soilType);

        Task Delete(int id);

        Task Update(SoilTypeEntity soilType);
    }
}