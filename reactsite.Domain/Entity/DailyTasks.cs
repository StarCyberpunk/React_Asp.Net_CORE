using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace reactsite.Domain.Entity
{
    public class DailyTasks
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public List<DayTasks> DayTasks { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }

    }
}
