using ApiRaizes.DTO;
using ApiRaizes.Entity;


namespace ApiRaizes.Contracts.Repository
{
    public interface IMeasureUnitRepository
    {
        Task<IEnumerable<MeasureUnitEntity>> GetAll();

        Task<MeasureUnitEntity> GetById(int id);

        Task Insert(MeasureUnitInsertDTO measureUnit);

        Task Delete(int id);

        Task Update(MeasureUnitEntity measureUnit);


    }
}