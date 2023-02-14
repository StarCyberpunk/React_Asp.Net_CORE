using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace reactsite.Domain.Enum
{
    public enum TypeRobot
    {
        [Display(Name = "Промышленный")]
        PromshRobot = 0,
        [Display(Name = "Домашний")]
        HomeRobot = 1,
        [Display(Name = "Умный дом")]
        BrainRobot = 2,
    }
}
