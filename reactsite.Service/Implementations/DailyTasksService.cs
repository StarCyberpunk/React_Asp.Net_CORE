using Microsoft.EntityFrameworkCore;
using reactsite.DAL.Interfaces;
using reactsite.Domain.Entity;
using reactsite.Domain.Response;
using reactsite.Domain.ViewModels;
using reactsite.Service.Interfaces;
using System;
using System.Collections.Generic;
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
        public async Task<BaseResponse<DailyTasksViewModel>> GetDailyTask(int Userid)
        {
            BaseResponse<DailyTasksViewModel> baseResponse = new BaseResponse<DailyTasksViewModel>();
            try
            {
                var task = await _DT_Repo.Select()
                    .Include(x => x.Activites).FirstOrDefaultAsync(x => x.UserId == Userid);
                
                if (task.Activites.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 эл-в";
                    baseResponse.Data = null;
                }
                else
                {
                    baseResponse.Description = "";
                    baseResponse.Data = ToVM(task);
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex)
            {
                var z = new BaseResponse<DailyTasksViewModel>();
                z.Description = $"[GetDailyTasks]:{ex.Message}";

                return z;
            }
            
        }
        public DailyTasksViewModel ToVM(DailyTasks dt)
        {

            DailyTasksViewModel dwm = new DailyTasksViewModel()
            {
                Day = dt.Day,
                Activites = AcToVM(dt.Activites),
                   Id=dt.Id,
                   UserId=dt.UserId
                   
                };
            
            return dwm;
        }
        public List<ActivityViewModel> AcToVM(List<Activity> a)
        {
            List<ActivityViewModel> res = new List<ActivityViewModel>();
            foreach(Activity aa in a)
            {
                ActivityViewModel t = new ActivityViewModel()
                {
                    Id = aa.Id,
                    Name = aa.Name,
                    TypeActivity = aa.TypeActivity,
                    DailyTasksId = aa.DailyTasksId,
                    DateBegin = aa.DateBegin,
                    DateEnd = aa.DateEnd,
                    UserId = aa.Id
                };
                res.Add(t);
            }
            return res;
        }
    }
}
