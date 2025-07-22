using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class SoilTypeService : ISoilTypeService
    {
        private readonly ISoilTypeRepository _repository;

        public SoilTypeService(ISoilTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Tipo de solo excluído com sucesso!"
            };
        }

        public async Task<SoilTypeGetAllResponse> GetAll()
        {
            return new SoilTypeGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<SoilTypeEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(SoilTypeInsertDTO soilType)
        {
            await _repository.Insert(soilType);
            return new MessageAllResponse
            {
                Message = "Tipo de solo inserido com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(SoilTypeEntity soilType)
        {
            await _repository.Update(soilType);
            return new MessageAllResponse
            {
                Message = "Tipo de solo alterado com sucesso"
            };
        }
    }
}
