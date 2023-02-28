using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using reactsite.Domain.Entity;
using reactsite.Service.Interfaces;
using reactsite.Domain.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace reactsite.backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyTasksController : ControllerBase
    {
        private readonly IDailyTasksService _dts;
        private long UserId=>long.Parse( User.Claims.Single(c=>c.Type==ClaimTypes.NameIdentifier).Value);
        public DailyTasksController(IDailyTasksService d)
        {
            _dts = d;
        }
        [HttpGet(Name = "DailyTasks")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<DailyTasksViewModel>> GetDailyTasks()
        {
            var r = await _dts.GetDailyTask(UserId);
            List<DailyTasksViewModel> a = new List<DailyTasksViewModel>();
            a.Add(r.Data);
            return a; 
        }
    }
}
