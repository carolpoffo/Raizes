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
    public class MeasureUnitController : ControllerBase
    {

        private IMeasureUnitService _service;
        public MeasureUnitController(IMeasureUnitService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<MeasureUnitGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MeasureUnitEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(MeasureUnitInsertDTO measureUnit)
        {
            return Ok(await _service.Post(measureUnit));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(MeasureUnitEntity measureUnit)
        {
            return Ok(await _service.Update(measureUnit));
        }
    }
}