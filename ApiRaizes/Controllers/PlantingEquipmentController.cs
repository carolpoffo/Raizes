using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRaizes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PlantingEquipmentController : ControllerBase
    {
        private IPlantingEquipmentService _service;

        public PlantingEquipmentController(IPlantingEquipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PlantingEquipmentGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantingEquipmentEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(PlantingEquipmentInsertDTO plantingEquipment)
        {
            return Ok(await _service.Post(plantingEquipment));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(PlantingEquipmentEntity plantingEquipment)
        {
            return Ok(await _service.Update(plantingEquipment));
        }
    }
}