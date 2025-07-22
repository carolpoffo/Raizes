using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IEventService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<EventGetAllResponse> GetAll();
        Task<EventEntity> GetById(int id);
        Task<MessageAllResponse> Post(EventInsertDTO Event);
        Task<MessageAllResponse> Update(EventEntity Event);
    }
}