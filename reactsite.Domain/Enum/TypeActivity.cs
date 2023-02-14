using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace reactsite.Domain.Enum
{
    public enum TypeActivity
    {
        [Display(Name = "Работа")]
        Work = 0,
        [Display(Name = "Саморазвитие")]
        SelfUpgrade = 1,
        [Display(Name = "Отдых")]
        Rest = 2,
    }
}
