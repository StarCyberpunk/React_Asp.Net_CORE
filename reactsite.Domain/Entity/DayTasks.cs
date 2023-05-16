using reactsite.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace reactsite.Domain.Entity
{
    public class DayTasks
    {
        public long Id { get; set; }
        public long DailyTasksId { get; set; }
        public long UserId { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public int NowActivity { get; set; }
        public List<Activity>? Activites { get; set; }
        [JsonIgnore]
        public virtual DailyTasks? DailyTasks { get; set; }
    }
}
