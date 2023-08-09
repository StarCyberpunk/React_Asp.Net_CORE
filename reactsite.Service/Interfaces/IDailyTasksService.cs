using reactsite.Domain.Entity;
using reactsite.Domain.Response;
using reactsite.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Service.Interfaces
{
    public interface IDailyTasksService
    {
        /*Task<BaseResponse<bool>> CreateProfile(ProfileViewModel p);*/
        Task<BaseResponse<DailyTasks>> GetDailyTask(long userid,DayTaskViewModel dtvm);
         Task<BaseResponse<List<DailyTasks>>> GetDailyTaskWeekly(long userid);
         Task<BaseResponse<string>> NewDailyTask(long userid, DailyTasksViewModel d);
    }
}
