using System.Collections.Generic;
using System.Threading.Tasks;
using Application.User;
using Domain.Models.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : BaseController
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<User>> CurrentUser()
        {
            return await Mediator.Send(new CurrentUser.Query());
        }

        [HttpGet("getUser")]
        [AllowAnonymous]
        public async Task<ActionResult<List<User>>> GetUserRecord()
        {
            return await Mediator.Send(new AllUser.Query());
        }
    }
}