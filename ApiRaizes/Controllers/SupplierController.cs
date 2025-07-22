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
    public class SupplierController : ControllerBase
    {

        private ISupplierService _service;
        public SupplierController(ISupplierService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<SupplierGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(SupplierInsertDTO supplier)
        {
            return Ok(await _service.Post(supplier));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(SupplierEntity supplier)
        {
            return Ok(await _service.Update(supplier));
        }
    }
}