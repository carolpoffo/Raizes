using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentService(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Equipamento excluído com sucesso!"
            };
        }

        public async Task<EquipmentGetAllResponse> GetAll()
        {
            return new EquipmentGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<EquipmentEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(EquipmentInsertDTO equipment)
        {
            await _repository.Insert(equipment);
            return new MessageAllResponse
            {
                Message = "Equipamento inserido com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(EquipmentEntity equipment)
        {
            await _repository.Update(equipment);
            return new MessageAllResponse
            {
                Message = "Equipamento alterado com sucesso!"
            };
        }
    }
}
