using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Domain.Entity
{
    public class DailyTasks
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime Day { get; set; }
        public User? User { get; set; }
        public List<Activity>? Activites { get; set; }
    }
}
