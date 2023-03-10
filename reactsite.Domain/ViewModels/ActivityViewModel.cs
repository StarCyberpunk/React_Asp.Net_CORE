using reactsite.Domain.Entity;
using reactsite.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Domain.ViewModels
{
    public class ActivityViewModel
    {
        public long Id { get; set; }
        public long DailyTasksId { get; set; }
        public long UserId { get; set; }
        public string? Name { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public TypeActivity TypeActivity { get; set; }
        
    }
}
