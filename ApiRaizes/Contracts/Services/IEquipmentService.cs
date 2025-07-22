using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IEquipmentService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<EquipmentGetAllResponse> GetAll();
        Task<EquipmentEntity> GetById(int id);
        Task<MessageAllResponse> Post(EquipmentInsertDTO equipment);
        Task<MessageAllResponse> Update(EquipmentEntity equipment);
    }
}