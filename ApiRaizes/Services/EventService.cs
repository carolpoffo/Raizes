using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Evento excluído com sucesso!"
            };
        }

        public async Task<EventGetAllResponse> GetAll()
        {
            return new EventGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<EventEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(EventInsertDTO Event)
        {
            await _repository.Insert(Event);
            return new MessageAllResponse
            {
                Message = "Evento inserido com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(EventEntity Event)
        {
            await _repository.Update(Event);
            return new MessageAllResponse
            {
                Message = "Evento alterado com sucesso"
            };
        }
    }
}
