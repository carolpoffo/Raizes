using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;
using ApiRaizes.Response.User;

namespace ApiRaizes.Contracts.Services
{
    public interface IUserService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<UserGetAllResponse> GetAll();
        Task<UserEntity> GetById(int id);
        Task<MessageAllResponse> Post(UserInsertDTO user);
        Task<MessageAllResponse> Update(UserEntity user);
        Task<UserLoginTokenAllResponse> Login(UserLoginInsertDTO user);
    }
}