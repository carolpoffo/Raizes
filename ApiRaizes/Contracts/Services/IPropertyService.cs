using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IPropertyService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<PropertyGetAllResponse> GetAll();
        Task<PropertyEntity> GetById(int id);
        Task<MessageAllResponse> Post(PropertyInsertDTO property);
        Task<MessageAllResponse> Update(PropertyEntity property);
    }
}