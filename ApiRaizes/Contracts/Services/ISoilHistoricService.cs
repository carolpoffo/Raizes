using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISoilHistoricService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<SoilHistoricGetAllResponse> GetAll();
        Task<SoilHistoricEntity> GetById(int id);
        Task<MessageAllResponse> Post(SoilHistoricInsertDTO soilHistoric);
        Task<MessageAllResponse> Update(SoilHistoricEntity soilHistoric);
    }
}