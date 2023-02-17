using Microsoft.AspNetCore.Mvc;
using reactsite.Domain.Entity;
using reactsite.Service.Implementations;
using reactsite.Service.Interfaces;

namespace reactsite.backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _ac;
        public UserController(IAccountService ac)
        {
            _ac = ac;
        }
        [HttpGet(Name = "User")]
        public async Task<IEnumerable<User>> Get()
        {
            var r = await _ac.GetAllUsers();
            
            return r.Data ;
        }
    }
}
