using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<PropertyEntity>> GetAll();

        Task<PropertyEntity> GetById(int id);

        Task Insert(PropertyInsertDTO property);

        Task Delete(int id);

        Task Update(PropertyEntity property);
    }
}