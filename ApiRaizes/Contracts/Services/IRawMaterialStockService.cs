using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IRawMaterialStockService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<RawMaterialStockGetAllResponse> GetAll();
        Task<RawMaterialStockEntity> GetById(int id);
        Task<MessageAllResponse> Post(RawMaterialStockInsertDTO rawMaterialStock);
        Task<MessageAllResponse> Update(RawMaterialStockEntity rawMaterialStock);
    }
}