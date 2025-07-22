using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();

        Task<UserEntity> GetById(int id);

        Task Insert(UserInsertDTO user);

        Task Delete(int id);

        Task Update(UserEntity user);
        Task<UserEntity> Login(UserLoginInsertDTO user);
    }
}