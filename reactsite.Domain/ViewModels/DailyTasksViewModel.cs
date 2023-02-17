using reactsite.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Domain.ViewModels
{
    public class DailyTasksViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime Day { get; set; }
        public List<ActivityViewModel>? Activites { get; set; }
    }
}
