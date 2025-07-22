using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ISoilHistoricRepository
    {
        Task<IEnumerable<SoilHistoricEntity>> GetAll();

        Task<SoilHistoricEntity> GetById(int id);

        Task Insert(SoilHistoricInsertDTO soilHistoric);

        Task Delete(int id);

        Task Update(SoilHistoricEntity soilHistoric);
    }
}