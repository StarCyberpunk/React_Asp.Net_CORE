﻿using reactsite.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace reactsite.Domain.Entity
{
    public class Activity
    {
        public long Id { get; set; }
        public long DayTaskId { get; set; }
        public long UserId { get; set; }
        public string? Name { get; set; }
        public long Total { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public TypeActivity TypeActivity { get; set; }
        public TypeDoneActivity DoneType { get; set; }
        [JsonIgnore]
        public virtual DayTasks? DayTasks { get; set; }

    }
}
