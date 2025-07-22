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
    public class EventController : ControllerBase
    {

        private IEventService _service;
        public EventController(IEventService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<EventGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EventEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageAllResponse>> Post(EventInsertDTO Event)
        {
            try
            {
                var resultado = await _service.Post(Event);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO POST /Event] {ex.Message}");
                return StatusCode(500, "Erro interno no servidor.");
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(EventEntity Event)
        {
            return Ok(await _service.Update(Event));
        }
    }
}