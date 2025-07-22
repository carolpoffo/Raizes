using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetAll();

        Task<TaskEntity> GetById(int id);

        Task Insert(TaskInsertDTO task);

        Task Delete(int id);

        Task Update(TaskEntity task);
    }
}