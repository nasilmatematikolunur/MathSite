using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Entities.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
     
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto user)
        {
            var userToLogin = _authService.Login(user);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var token = _authService.CreateToken(userToLogin.Data);
            if (token.Success)
            {
                return Ok(token.Data);
            }

            return BadRequest(token);
        }


        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto user)
        {
            var userExists = _authService.UserExists(user.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }


            /*IDataResult<User>*/
            var registerResult = _authService.Register(user, user.Password);
            var token = _authService.CreateToken(registerResult.Data);
            if (token.Success)
            {
                return Ok(token.Data);
            }

            return BadRequest(token);
        }



    }
}
