using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using reactsite.Domain.Entity;
using reactsite.Service.Interfaces;
using reactsite.Domain.ViewModels;
using System.Collections.Generic;

namespace reactsite.backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyTasksController : ControllerBase
    {
        private readonly IDailyTasksService _dts;
        public DailyTasksController(IDailyTasksService d)
        {
            _dts = d;
        }
        [HttpGet(Name = "DailyTasks")]
        public async Task<IEnumerable<DailyTasksViewModel>> Get()
        {
            var r = await _dts.GetDailyTask(1);
            List<DailyTasksViewModel> a = new List<DailyTasksViewModel>();
            a.Add(r.Data);
            return a; 
        }
    }
}
