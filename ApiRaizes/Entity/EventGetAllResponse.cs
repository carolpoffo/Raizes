using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class EventGetAllResponse
    {
        public IEnumerable<EventEntity> Data { get; set; }
    }
}
