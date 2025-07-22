using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Venda excluída com sucesso!"
            };
        }

        public async Task<SaleGetAllResponse> GetAll()
        {
            return new SaleGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<SaleEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(SaleInsertDTO Sale)
        {
            await _repository.Insert(Sale);
            return new MessageAllResponse
            {
                Message = "Venda inserida com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(SaleEntity Sale)
        {
            await _repository.Update(Sale);
            return new MessageAllResponse
            {
                Message = "Venda alterada com sucesso"
            };
        }
    }
}
