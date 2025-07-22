using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class RawMaterialStockService : IRawMaterialStockService
    {
        private readonly IRawMaterialStockRepository _repository;

        public RawMaterialStockService(IRawMaterialStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Insumo excluído do estoque com sucesso!"
            };
        }

        public async Task<RawMaterialStockGetAllResponse> GetAll()
        {
            return new RawMaterialStockGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<RawMaterialStockEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(RawMaterialStockInsertDTO RawMaterialStock)
        {
            await _repository.Insert(RawMaterialStock);
            return new MessageAllResponse
            {
                Message = "Insumo inserido no estoque com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(RawMaterialStockEntity RawMaterialStock)
        {
            await _repository.Update(RawMaterialStock);
            return new MessageAllResponse
            {
                Message = "Insumo do estoque alterado com sucesso"
            };
        }
    }
}
