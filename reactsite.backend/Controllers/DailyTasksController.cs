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
        [HttpPost(Name = "DailyTasks")]
        [Authorize]
        public async Task<List<DailyTasks>> GetDailyTasks(DayTaskViewModel dtvm)
        {
            var r = await _dts.GetDailyTask(UserId,dtvm);
           
            return r.Data; 
        }
        [HttpGet(Name = "DailyTasksWeekly")]
        [Authorize]
        public async Task<List<DailyTasks>> GetDailyTasksWeekly()
        {
            var r = await _dts.GetDailyTaskWeekly(UserId);

            return r.Data;
        }
    }
}
