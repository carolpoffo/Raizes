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
    public class SpeciesController : ControllerBase
    {
        private ISpeciesService _service;
        public SpeciesController(ISpeciesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<SpeciesGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SpeciesEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(SpeciesInsertDTO species)
        {
            return Ok(await _service.Post(species));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(SpeciesEntity species)
        {
            return Ok(await _service.Update(species));
        }
    }
}

