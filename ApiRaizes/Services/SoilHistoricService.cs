using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class SoilHistoricService : ISoilHistoricService
    {
        private readonly ISoilHistoricRepository _repository;

        public SoilHistoricService(ISoilHistoricRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Histórico de solo excluído com sucesso!"
            };
        }

        public async Task<SoilHistoricGetAllResponse> GetAll()
        {
            return new SoilHistoricGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<SoilHistoricEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(SoilHistoricInsertDTO SoilHistoric)
        {
            await _repository.Insert(SoilHistoric);
            return new MessageAllResponse
            {
                Message = "Histórico de solo inserido com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(SoilHistoricEntity SoilHistoric)
        {
            await _repository.Update(SoilHistoric);
            return new MessageAllResponse
            {
                Message = "Histórico de solo alterado com sucesso"
            };
        }
    }
}
