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
    public class PlantingRawMaterialController : ControllerBase
    {
        private IPlantingRawMaterialService _service;

        public PlantingRawMaterialController(IPlantingRawMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PlantingRawMaterialGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantingRawMaterialEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(PlantingRawMaterialInsertDTO plantingRawMaterial)
        {
            return Ok(await _service.Post(plantingRawMaterial));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(PlantingRawMaterialEntity plantingRawMaterial)
        {
            return Ok(await _service.Update(plantingRawMaterial));
        }
    }
}