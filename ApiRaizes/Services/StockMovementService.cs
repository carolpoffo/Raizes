using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _repository;

        public StockMovementService(IStockMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Movimento do estoque excluído com sucesso!"
            };
        }

        public async Task<StockMovementGetAllResponse> GetAll()
        {
            return new StockMovementGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<StockMovementEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(StockMovementInsertDTO stockMovement)
        {
            await _repository.Insert(stockMovement);
            return new MessageAllResponse
            {
                Message = "Movimento do estoque inserido com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(StockMovementEntity stockMovement)
        {
            await _repository.Update(stockMovement);
            return new MessageAllResponse
            {
                Message = "Movimento do estoque alterado com sucesso!"
            };
        }
    }
}
