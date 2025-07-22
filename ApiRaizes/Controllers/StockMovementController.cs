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
    public class StockMovementController : ControllerBase
    {
        private IStockMovementService _service;

        public StockMovementController(IStockMovementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<StockMovementGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockMovementEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(StockMovementInsertDTO stockMovement)
        {
            return Ok(await _service.Post(stockMovement));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(StockMovementEntity stockMovement)
        {
            return Ok(await _service.Update(stockMovement));
        }
    }
}