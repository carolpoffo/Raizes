using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ISpeciesRepository
    {
        Task<IEnumerable<SpeciesEntity>> GetAll();
        Task<SpeciesEntity> GetById(int id);
        Task Insert(SpeciesInsertDTO species);
        Task Update(SpeciesEntity species);
        Task Delete(int id);
    }
}
