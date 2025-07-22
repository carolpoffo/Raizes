using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IRawMaterialService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<RawMaterialGetAllResponse> GetAll();
        Task<RawMaterialEntity> GetById(int id);
        Task<MessageAllResponse> Post(RawMaterialInsertDTO rawMaterial);
        Task<MessageAllResponse> Update(RawMaterialEntity rawMaterial);
    }
}