using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IPlantingEquipmentRepository
    {
        Task<IEnumerable<PlantingEquipmentEntity>> GetAll();

        Task<PlantingEquipmentEntity> GetById(int id);

        Task Insert(PlantingEquipmentInsertDTO plantingEquipment);

        Task Delete(int id);

        Task Update(PlantingEquipmentEntity plantingEquipment);
    }
}