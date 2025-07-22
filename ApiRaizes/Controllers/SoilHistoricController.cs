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
    public class SoilHistoricController : ControllerBase
    {
        private ISoilHistoricService _service;
        public SoilHistoricController(ISoilHistoricService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<SoilHistoricGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SoilHistoricEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(SoilHistoricInsertDTO soilHistoric)
        {
            return Ok(await _service.Post(soilHistoric));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(SoilHistoricEntity soilHistoric)
        {
            return Ok(await _service.Update(soilHistoric));
        }
    }
}