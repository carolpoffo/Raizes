using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<EquipmentEntity>> GetAll();

        Task<EquipmentEntity> GetById(int id);

        Task Insert(EquipmentInsertDTO equipment);

        Task Delete(int id);

        Task Update(EquipmentEntity equipment);
    }
}