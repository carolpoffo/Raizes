using ApiRaizes.Entity;

namespace ApiRaizes.Response.User
{
    public class UserLoginTokenAllResponse
    {
        public string Token { get; set; }
        public UserEntity User { get; set; }
    }
}