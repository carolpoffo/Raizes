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
    public class SoilTypeController : ControllerBase
    {
        private ISoilTypeService _service;

        public SoilTypeController(ISoilTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<SoilTypeGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SoilTypeEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(SoilTypeInsertDTO soilType)
        {
            return Ok(await _service.Post(soilType));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(SoilTypeEntity soilType)
        {
            return Ok(await _service.Update(soilType));
        }
    }
}