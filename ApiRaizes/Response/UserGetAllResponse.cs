using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class UserGetAllResponse
    {
        public IEnumerable<UserEntity> Data { get; set; }
    }
}