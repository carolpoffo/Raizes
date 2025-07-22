using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ISaleRepository
    {
        Task<IEnumerable<SaleEntity>> GetAll();
        Task<SaleEntity> GetById(int id);
        Task Insert(SaleInsertDTO Sale);
        Task Update(SaleEntity Sale);
        Task Delete(int id);
    }
}
