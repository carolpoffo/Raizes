using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISpeciesService
    {
        Task<MessageAllResponse> Delete(int id);
        Task<SpeciesGetAllResponse> GetAll();
        Task<SpeciesEntity> GetById(int id);
        Task<MessageAllResponse> Post(SpeciesInsertDTO species);
        Task<MessageAllResponse> Update(SpeciesEntity species);
    }
}