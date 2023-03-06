using reactsite.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace reactsite.Domain.Entity
{
    public class User
    {
        public long Id { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        public string? Login { get; set; }
        public Role Role { get; set; }
        public Profile? Profile { get; set; }
        public DailyTasks? DailyTasks { get; set; }

    }
}
