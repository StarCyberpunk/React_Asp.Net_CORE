using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using reactsite.Domain.Entity;
using reactsite.Domain.Helpers;
using reactsite.Domain.ViewModels;
using reactsite.Service.Implementations;
using reactsite.Service.Interfaces;
using System.Security.Claims;

namespace reactsite.backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _ac;
        private long UserId => long.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public UserController(IAccountService ac)
        {
            _ac = ac;
            

        }
        /*[HttpGet(Name = "User")]
        public async Task<IEnumerable<User>> Get()
        {
            var r = await _ac.GetAllUsers();
            
            return r.Data ;
        }*/

        [HttpGet(Name = "User")]
        [Authorize]
        public async Task<IActionResult> GetById()
        {
            var res = await _ac.GetUserById(UserId);
            if (res.StatusCode == Domain.Enum.StatusCode.NotFound)
            {
                return BadRequest(new { message = "NotFound" });
            }
            return Ok(new
            {
                User = res.Data
            });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            var res = await _ac.Register(rvm);
            if(res.StatusCode== Domain.Enum.StatusCode.NotFound)
            {
                return BadRequest(new { message = "UNREGISTER" });
            }
            return Ok(new
            {
                access_token=res.Data
            });
        }
        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] LoginViewModel lvm)
        {
            var res = await _ac.Login(lvm);
            if (res.StatusCode == Domain.Enum.StatusCode.NotFound)
            {
                return BadRequest(new { message = "NOTFOUND" });
            }
            else if (res.StatusCode == Domain.Enum.StatusCode.WrongData)
            {
                return BadRequest(new { message = "WRONGDATA" });
            }
            return Ok(new
            {
                access_token = res.Data
            });
        }
    }
    
    
}
