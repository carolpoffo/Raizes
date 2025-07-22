using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISaleService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<SaleGetAllResponse> GetAll();
        Task<SaleEntity> GetById(int id);
        Task<MessageAllResponse> Post(SaleInsertDTO sale);
        Task<MessageAllResponse> Update(SaleEntity sale);
    }
}