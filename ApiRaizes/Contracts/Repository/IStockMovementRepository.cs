using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IStockMovementRepository
    {
        Task<IEnumerable<StockMovementEntity>> GetAll();

        Task<StockMovementEntity> GetById(int id);

        Task Insert(StockMovementInsertDTO stockMovement);

        Task Delete(int id);

        Task Update(StockMovementEntity stockMovement);
    }
}