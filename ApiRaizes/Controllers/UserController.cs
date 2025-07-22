using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Infrastructure;
using ApiRaizes.Response;
using ApiRaizes.Response.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRaizes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet("HandShake")]
        public IActionResult HandShake()
        {
            return Ok(new
            {
                message = "Token válido",
                user = User.Identity?.Name,
                authenticated = true
            });
        }

        [HttpGet]
        public async Task<ActionResult<UserGetAllResponse>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<MessageAllResponse>> Post(UserInsertDTO user)
        {
            return Ok(await _service.Post(user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageAllResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageAllResponse>> Update(UserEntity user)
        {
            user.Senha = Criptografy.Criptografia(user.Senha);
            return Ok(await _service.Update(user));
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginTokenAllResponse>> Login(UserLoginInsertDTO user)
        {
            try
            {
                return Ok(await _service.Login(user));
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}