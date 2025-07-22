using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IStockMovementService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<StockMovementGetAllResponse> GetAll();
        Task<StockMovementEntity> GetById(int id);
        Task<MessageAllResponse> Post(StockMovementInsertDTO stockMovement);
        Task<MessageAllResponse> Update(StockMovementEntity stockMovement);
    }
}