using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace reactsite.Domain.Enum
{
    public enum TypeDoneActivity
    {
        [Display(Name = "Не выполнена")]
        Work = 0,
        [Display(Name = "В ходе работы")]
        SelfUpgrade = 1,
        [Display(Name = "Выполнена")]
        Rest = 2,
    }
}
