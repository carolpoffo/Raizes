using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _repository;

        public MeasureUnitService(IMeasureUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageAllResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageAllResponse
            {
                Message = "Unidade de medida excluída com sucesso!"
            };
        }

        public async Task<MeasureUnitGetAllResponse> GetAll()
        {
            return new MeasureUnitGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<MeasureUnitEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageAllResponse> Post(MeasureUnitInsertDTO measureUnit)
        {
            await _repository.Insert(measureUnit);
            return new MessageAllResponse
            {
                Message = "Unidade de medida inserida com sucesso!"
            };
        }

        public async Task<MessageAllResponse> Update(MeasureUnitEntity measureUnit)
        {
            await _repository.Update(measureUnit);
            return new MessageAllResponse
            {
                Message = "Unidade de medida alterada com sucesso"
            };
        }
    }
}
