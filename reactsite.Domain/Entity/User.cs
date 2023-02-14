using reactsite.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Domain.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }
        public Profile Profile { get; set; }
        public List<DailyTasks> DailysTasks { get; set; } 
        
    }
}
