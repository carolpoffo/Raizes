using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISoilTypeService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<SoilTypeGetAllResponse> GetAll();
        Task<SoilTypeEntity> GetById(int id);
        Task<MessageAllResponse> Post(SoilTypeInsertDTO soilType);
        Task<MessageAllResponse> Update(SoilTypeEntity soilType);
    }
}