using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Tarefa excluída com sucesso!"
            };
        }

        public async Task<TaskGetAllResponse> GetAll()
        {
            return new TaskGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<TaskEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(TaskInsertDTO Task)
        {
            await _repository.Insert(Task);
            return new MessageAllResponse
            {
                Message = "Tarefa inserida com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(TaskEntity Task)
        {
            await _repository.Update(Task);
            return new MessageAllResponse
            {
                Message = "Tarefa alterada com sucesso"
            };
        }
    }
}
