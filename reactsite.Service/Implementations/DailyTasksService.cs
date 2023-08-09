using Microsoft.EntityFrameworkCore;
using reactsite.DAL.Interfaces;
using reactsite.Domain.Entity;
using reactsite.Domain.Enum;
using reactsite.Domain.Response;
using reactsite.Domain.ViewModels;
using reactsite.Service.Interfaces;
using System.Globalization;

namespace reactsite.Service.Implementations
{
    public class DailyTasksService : IDailyTasksService
    {
        private readonly IBaseRepository<DailyTasks> _DT_Repo;
        private readonly IBaseRepository<User> _us_Repo;
        private readonly IBaseRepository<Activity> _ac_Repo;
        private readonly IBaseRepository<DayTasks> _DayTa_Repo;
        public DailyTasksService(IBaseRepository<DailyTasks> dt, IBaseRepository<User> us,
            IBaseRepository<Activity> ac, IBaseRepository<DayTasks> dayt)
        {
            _DT_Repo = dt;
            _us_Repo = us;
            _ac_Repo = ac;
            _DayTa_Repo = dayt;
        }
        public async Task<BaseResponse< DailyTasks>> GetDailyTask(long Userid,DayTaskViewModel dtvm)
        {
            BaseResponse<DailyTasks> baseResponse = new BaseResponse<DailyTasks>();
            try
            {
                var start = new DateTime(dtvm.start.Year, dtvm.start.Month, dtvm.start.Day, 0, 0, 0);
                var end = new DateTime(dtvm.start.Year, dtvm.start.Month, dtvm.start.Day, 23, 59, 59);
                var task = await _DT_Repo.Select()
                    .Include(x => x.DayTasks.Where(t => t.Date == start && t.UserId == Userid))
                    .ThenInclude(x => x.Activites.Where(t => t.DateBegin > start && t.DateEnd < end && t.UserId == Userid))
                    .Where(x => x.UserId == Userid).FirstOrDefaultAsync();
                
                if (task == null)
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
                var z = new BaseResponse<DailyTasks>();
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
                    .Include(x => x.DayTasks.Where(t => t.Date > weekStart && t.Date < weekEnd && t.UserId == Userid))
                    .ThenInclude(x => x.Activites)
                    .Where(x => x.UserId == Userid)
                    
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
        
        public async Task<BaseResponse<string>> NewDailyTask(long UserId, DailyTasksViewModel d)
        {
            BaseResponse<string> baseResponse = new BaseResponse<string>();
            try
            {
                var task = await _DT_Repo.Select()
                    .Include(x=>x.DayTasks.Where(x=>x.Date== DateTime.Parse(d.Day)))
                    .ThenInclude(x => x.Activites)
                    .Where(x => x.UserId == UserId)
                    .FirstOrDefaultAsync();
                var us = await _us_Repo.Select().Where(x => x.Id == UserId).FirstOrDefaultAsync();
                var dayTask = await _DayTa_Repo.Select().Where(x => x.Date == DateTime.Parse(d.Day)&& x.UserId == UserId).FirstOrDefaultAsync();
                if (task != null)
                {
                    if (dayTask != null)
                    {
                        foreach (var z in d.Activites)
                        {
                            var DB = DateTime.Parse(z.DateBegin,null, System.Globalization.DateTimeStyles.RoundtripKind);
                            var DE= DateTime.Parse(z.DateEnd, null, System.Globalization.DateTimeStyles.RoundtripKind);
                            var t = await _ac_Repo.Select()
                                .Where(x => x.Name==z.Name)
                                .Where(x=>x.DateBegin.Month==DB.Month&&x.DateBegin.Day==DB.Day)
                                .FirstOrDefaultAsync();
                            var zt = new Activity
                            {
                                DayTasks = dayTask,
                                DayTaskId = dayTask.Id,
                                DateBegin = DateTime.Parse(z.DateBegin, null, System.Globalization.DateTimeStyles.RoundtripKind),
                                DateEnd = DateTime.Parse(z.DateEnd, null, System.Globalization.DateTimeStyles.RoundtripKind),
                                DoneType = 0,
                                Name = z.Name,
                                Total = z.Total,
                                TypeActivity = z.TypeActivity,
                                UserId = UserId
                            };
                            if (t == null)
                            {
                                await _ac_Repo.Create(zt);
                            }
                            else
                            {
                                 await _ac_Repo.Update(zt);
                            }
                            
                        }
                    }
                    else
                    {
                        var dayTasknew = new DayTasks
                        {
                            UserId = UserId,
                            DailyTasks = task,
                            DailyTasksId = task.Id,
                            Activites = new List<Activity>(),
                            Date = DateTime.Parse(d.Day),
                            NowActivity = 0,
                            Name = ""
                        };
                        await _DayTa_Repo.Create(dayTasknew);
                        dayTask = await _DayTa_Repo.Select().Where(x => x.Date == DateTime.Parse(d.Day) && x.UserId == UserId).FirstOrDefaultAsync();
                        if (d.Activites != null)
                        {
                            foreach (var t in d.Activites)
                            {
                                var DB = DateTime.Parse(t.DateBegin, null, System.Globalization.DateTimeStyles.RoundtripKind);
                                var DE = DateTime.Parse(t.DateEnd, null, System.Globalization.DateTimeStyles.RoundtripKind);
                                var aci = await _ac_Repo.Select()
                                    .Where(x => x.Name == t.Name)
                                    .Where(x => x.DateBegin.Month == DB.Month && x.DateBegin.Day == DB.Day)
                                    .FirstOrDefaultAsync();
                                var z = new Activity
                                {
                                    DayTasks = dayTask,
                                    DayTaskId = dayTask.Id,
                                    DateBegin = DateTime.Parse(t.DateBegin, null, System.Globalization.DateTimeStyles.RoundtripKind),
                                    DateEnd = DateTime.Parse(t.DateEnd, null, System.Globalization.DateTimeStyles.RoundtripKind),
                                    DoneType = 0,
                                    Name = t.Name,
                                    Total = t.Total,
                                    TypeActivity = t.TypeActivity,
                                    UserId = UserId
                                };
                                await _ac_Repo.Create(z);
                                
                            }
                        }
                    }
                    return new BaseResponse<string>()
                    {
                        Description = "Обновили",
                        StatusCode = StatusCode.OK
                    };
                }
                var reaa = new DailyTasks()
                {

                    DayTasks=new List<DayTasks>(),
                    UserId = UserId,
                    User = us
                };
                await _DT_Repo.Create(reaa);


                 task = await _DT_Repo.Select()
                    .Include(x => x.DayTasks.Where(x => x.Date == DateTime.Parse(d.Day)))
                    .ThenInclude(x=>x.Activites)
                    .Where(x => x.UserId == UserId)
                    .FirstOrDefaultAsync();
                var r = new List<Activity>();
                if (d.Activites != null) { 
                foreach (var z in d.Activites)
                {
                        var DB = DateTime.Parse(z.DateBegin, null, System.Globalization.DateTimeStyles.RoundtripKind);
                        var DE = DateTime.Parse(z.DateEnd, null, System.Globalization.DateTimeStyles.RoundtripKind);
                        var t = await _ac_Repo.Select()
                            .Where(x => x.Name == z.Name)
                            .Where(x => x.DateBegin.Month == DB.Month && x.DateBegin.Day == DB.Day)
                            .FirstOrDefaultAsync();
                        var ac = new Activity
                    {
                            DayTasks = dayTask,
                            DayTaskId = dayTask.Id,
                            DateBegin = DateTime.Parse(z.DateBegin, null, System.Globalization.DateTimeStyles.RoundtripKind),
                            DateEnd = DateTime.Parse(z.DateEnd, null, System.Globalization.DateTimeStyles.RoundtripKind),
                            DoneType = 0,
                            Name = t.Name,
                            Total = t.Total,
                            TypeActivity = t.TypeActivity,
                            UserId = UserId
                        };
                    await _ac_Repo.Create(ac);
                    r.Add(ac);
                }
                dayTask.Activites = r;
                await _DayTa_Repo.Update(dayTask);
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<string>();
                z.Description = $"[GetDailyTasks]:{ex.Message}";

                return z;
            }
        }
    }
}
