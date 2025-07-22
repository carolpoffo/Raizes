using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Cidade excluída com sucesso!"
            };
        }

        public async Task<CityGetAllResponse> GetAll()
        {
            return new CityGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<CityEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(CityInsertDTO city)
        {
            await _repository.Insert(city);
            return new MessageAllResponse
            {
                Message = "Cidade inserida com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(CityEntity city)
        {
            await _repository.Update(city);
            return new MessageAllResponse
            {
                Message = "Cidade alterada com sucesso"
            };
        }
    }
}
