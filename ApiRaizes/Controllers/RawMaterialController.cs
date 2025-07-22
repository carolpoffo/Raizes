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
    public class RawMaterialController : ControllerBase
    {
        private IRawMaterialService _service;

        public RawMaterialController(IRawMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<RawMaterialGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RawMaterialEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(RawMaterialInsertDTO rawMaterial)
        {
            return Ok(await _service.Post(rawMaterial));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(RawMaterialEntity rawMaterial)
        {
            return Ok(await _service.Update(rawMaterial));
        }
    }
}