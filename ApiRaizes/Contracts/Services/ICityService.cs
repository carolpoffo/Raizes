using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ICityService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<CityGetAllResponse> GetAll();
        Task<CityEntity> GetById(int id);
        Task<MessageAllResponse> Post(CityInsertDTO city);
        Task<MessageAllResponse> Update(CityEntity city);
    }
}