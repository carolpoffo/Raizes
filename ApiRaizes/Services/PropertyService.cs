using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;

        public PropertyService(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Propriedade excluída com sucesso!"
            };
        }

        public async Task<PropertyGetAllResponse> GetAll()
        {
            return new PropertyGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<PropertyEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(PropertyInsertDTO Property)
        {
            await _repository.Insert(Property);
            return new MessageAllResponse
            {
                Message = "Propriedade inserida com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(PropertyEntity Property)
        {
            await _repository.Update(Property);
            return new MessageAllResponse
            {
                Message = "Propriedade alterada com sucesso"
            };
        }
    }
}
