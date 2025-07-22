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
    public class PropertyController : ControllerBase
    {
        private IPropertyService _service;
        public PropertyController(IPropertyService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<PropertyGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(PropertyInsertDTO property)
        {
            return Ok(await _service.Post(property));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(PropertyEntity property)
        {
            return Ok(await _service.Update(property));
        }
    }
}