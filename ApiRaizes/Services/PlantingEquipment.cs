using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class PlantingEquipmentService : IPlantingEquipmentService
    {
        private readonly IPlantingEquipmentRepository _repository;

        public PlantingEquipmentService(IPlantingEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Equipamento excluído do plantio com sucesso!"
            };
        }

        public async Task<PlantingEquipmentGetAllResponse> GetAll()
        {
            return new PlantingEquipmentGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<PlantingEquipmentEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(PlantingEquipmentInsertDTO plantingEquipment)
        {
            await _repository.Insert(plantingEquipment);
            return new MessageAllResponse
            {
                Message = "Equipamento inserido no plantio com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(PlantingEquipmentEntity plantingEquipment)
        {
            await _repository.Update(plantingEquipment);
            return new MessageAllResponse
            {
                Message = "Equipamento do plantio alterado com sucesso"
            };
        }
    }
}
