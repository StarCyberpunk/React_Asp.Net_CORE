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
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
        public string DoneType { get; set; }
        public long Total { get; set; }
        public TypeActivity TypeActivity { get; set; }
        
        
    }
}
