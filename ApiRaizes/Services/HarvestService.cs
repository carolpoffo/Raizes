using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class HarvestService : IHarvestService
    {
        private readonly IHarvestRepository _repository;

        public HarvestService(IHarvestRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Colheita excluída com sucesso!"
            };
        }

        public async Task<HarvestGetAllResponse> GetAll()
        {
            return new HarvestGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<HarvestEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(HarvestInsertDTO harvest)
        {
            await _repository.Insert(harvest);
            return new MessageAllResponse
            {
                Message = "Colheita inserida com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(HarvestEntity harvest)
        {
            await _repository.Update(harvest);
            return new MessageAllResponse
            {
                Message = "Colheita alterada com sucesso"
            };
        }
    }
}
