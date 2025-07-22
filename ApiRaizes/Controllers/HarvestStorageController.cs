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
    public class HarvestStorageController : ControllerBase
    {
        private IHarvestStorageService _service;
        public HarvestStorageController(IHarvestStorageService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<HarvestStorageGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HarvestStorageEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(HarvestStorageInsertDTO harvestStorage)
        {
            return Ok(await _service.Post(harvestStorage));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(HarvestStorageEntity harvestStorage)
        {
            return Ok(await _service.Update(harvestStorage));
        }
    }
}
