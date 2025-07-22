using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventEntity>> GetAll();

        Task<EventEntity> GetById(int id);

        Task Insert(EventInsertDTO Event);

        Task Delete(int id);

        Task Update(EventEntity Event);
    }
}