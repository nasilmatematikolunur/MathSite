using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetList();
            if (users.Success)
            {
                return Ok(users);
            }
            
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
