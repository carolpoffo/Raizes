using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IMeasureUnitService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<MeasureUnitGetAllResponse> GetAll();
        Task<MeasureUnitEntity> GetById(int id);
        Task<MessageAllResponse> Post(MeasureUnitInsertDTO measureUnit);
        Task<MessageAllResponse> Update(MeasureUnitEntity measureUnit);
    }
}