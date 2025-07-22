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
    public class HarvestController : ControllerBase
    {
        private IHarvestService _service;

        public HarvestController(IHarvestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<HarvestGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HarvestEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(HarvestInsertDTO harvest)
        {
            return Ok(await _service.Post(harvest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(HarvestEntity harvest)
        {
            return Ok(await _service.Update(harvest));
        }
    }
}