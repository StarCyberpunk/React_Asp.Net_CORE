using Microsoft.EntityFrameworkCore;
using reactsite.DAL.Interfaces;
using reactsite.Domain.Entity;
using reactsite.Domain.Response;
using reactsite.Domain.ViewModels;
using reactsite.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Service.Implementations
{
    public class DailyTasksService : IDailyTasksService
    {
        private readonly IBaseRepository<DailyTasks> _DT_Repo;
        private readonly IBaseRepository<User> _us_Repo;
        public DailyTasksService(IBaseRepository<DailyTasks> dt, IBaseRepository<User> us)
        {
            _DT_Repo = dt;
            _us_Repo = us;
        }
        public async Task<BaseResponse<List< DailyTasks>>> GetDailyTask(long Userid,DayTaskViewModel dtvm)
        {
            BaseResponse<List<DailyTasks>> baseResponse = new BaseResponse<List<DailyTasks>>();
            try
            {
                var start = new DateTime(dtvm.start.Year, dtvm.start.Month, dtvm.start.Day, 0, 0, 0);
                var end = new DateTime(dtvm.start.Year, dtvm.start.Month, dtvm.start.Day, 23, 59, 59);
                var task = await _DT_Repo.Select()
                    .Include(x => x.Activites)
                    .Where(x=>x.UserId==Userid)
                    .Where(x=>x.Day>=start&&x.Day<=end)
                    .ToListAsync();
                
                if (task.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 эл-в";
                    baseResponse.Data = null;
                }
                else
                {
                    baseResponse.Description = "";
                    baseResponse.Data =task ;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex)
            {
                var z = new BaseResponse<List<DailyTasks>>();
                z.Description = $"[GetDailyTasks]:{ex.Message}";

                return z;
            }
            
        }

        public async Task<BaseResponse<List<DailyTasks>>> GetDailyTaskWeekly(long Userid)
        {
            BaseResponse<List<DailyTasks>> baseResponse = new BaseResponse<List<DailyTasks>>();
            try
            {
                DateTime today = DateTime.Today;
                var cultureStart = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                var weekStart = today;
                while (weekStart.DayOfWeek != cultureStart) weekStart = weekStart.AddDays(-1);
                var weekEnd = weekStart.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
                var task = await _DT_Repo.Select()
                    .Include(x => x.Activites)
                    .Where(x => x.UserId == Userid)
                    .Where(x => x.Day >= weekStart && x.Day <= weekEnd)
                    .ToListAsync();

                if (task.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 эл-в";
                    baseResponse.Data = null;
                }
                else
                {
                    baseResponse.Description = "";
                    baseResponse.Data = task;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<List<DailyTasks>>();
                z.Description = $"[GetDailyTasks]:{ex.Message}";

                return z;
            }
        }
    }
}
