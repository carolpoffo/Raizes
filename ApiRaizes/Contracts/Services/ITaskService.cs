using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ITaskService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<TaskGetAllResponse> GetAll();
        Task<TaskEntity> GetById(int id);
        Task<MessageAllResponse> Post(TaskInsertDTO task);
        Task<MessageAllResponse> Update(TaskEntity task);
    }
}