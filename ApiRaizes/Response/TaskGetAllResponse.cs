using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class TaskGetAllResponse
    {
        public IEnumerable<TaskEntity> Data { get; set; }
    }
}
