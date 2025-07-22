using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IRawMaterialRepository
    {
        Task<IEnumerable<RawMaterialEntity>> GetAll();

        Task<RawMaterialEntity> GetById(int id);

        Task Insert(RawMaterialInsertDTO rawMaterial);

        Task Delete(int id);

        Task Update(RawMaterialEntity rawMaterial);
    }
}
