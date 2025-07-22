using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly ISpeciesRepository _repository;

        public SpeciesService(ISpeciesRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Espécie excluída com sucesso!"
            };
        }

        public async Task<SpeciesGetAllResponse> GetAll()
        {
            return new SpeciesGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<SpeciesEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(SpeciesInsertDTO Species)
        {
            await _repository.Insert(Species);
            return new MessageAllResponse
            {
                Message = "Espécie inserida com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(SpeciesEntity Species)
        {
            await _repository.Update(Species);
            return new MessageAllResponse
            {
                Message = "Espécie alterada com sucesso"
            };
        }
    }
}
