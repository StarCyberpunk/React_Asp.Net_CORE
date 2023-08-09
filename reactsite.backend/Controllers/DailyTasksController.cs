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
        [HttpGet(Name = "DailyTasksWeekly")]
        [Authorize]
        public async Task<List<DailyTasks>> GetDailyTasksWeekly()
        {
            var r = await _dts.GetDailyTaskWeekly(UserId);

            return r.Data;
        }
        [HttpPost( "GetAll")]
        [Authorize]
        public async Task<DailyTasks> GetDailyTasks(DayTaskViewModel dtvm)
        {
            var r = await _dts.GetDailyTask(UserId,dtvm);
           
            return r.Data; 
        }

        [HttpPost("NewOrUpdate")]
        [Authorize]
        public async Task<IActionResult> NewDailyTasks(DailyTasksViewModel d)
        {
            var res = await _dts.NewDailyTask(UserId, d);
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
