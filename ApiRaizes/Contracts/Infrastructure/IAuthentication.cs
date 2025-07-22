using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Infrastructure
{
    public interface IAuthentication
    {
        string GenerateToken(UserEntity user);
    }
}