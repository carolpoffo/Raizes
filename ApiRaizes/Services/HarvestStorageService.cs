using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class HarvestStorageService : IHarvestStorageService
    {
        private readonly IHarvestStorageRepository _repository;

        public HarvestStorageService(IHarvestStorageRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "armazenamento de colheita excluído com sucesso!"
            };
        }

        public async Task<HarvestStorageGetAllResponse> GetAll()
        {
            return new HarvestStorageGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<HarvestStorageEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(HarvestStorageInsertDTO harvestStorage)
        {
            await _repository.Insert(harvestStorage);
            return new MessageAllResponse
            {
                Message = "armazenamento de colheita inserido com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(HarvestStorageEntity harvestStorage)
        {
            await _repository.Update(harvestStorage);
            return new MessageAllResponse
            {
                Message = "armazenamento de colheita alterado com sucesso"
            };
        }
    }
}
