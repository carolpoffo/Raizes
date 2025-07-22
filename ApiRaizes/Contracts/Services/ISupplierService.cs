using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISupplierService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<SupplierGetAllResponse> GetAll();
        Task<SupplierEntity> GetById(int id);
        Task<MessageAllResponse> Post(SupplierInsertDTO supplier);
        Task<MessageAllResponse> Update(SupplierEntity supplier);
    }
}