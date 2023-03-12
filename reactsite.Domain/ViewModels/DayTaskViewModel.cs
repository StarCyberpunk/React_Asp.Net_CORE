using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Domain.ViewModels
{
    public class DayTaskViewModel
    {
        [Required(ErrorMessage = "Старт")]
        public DateTime start { get; set; }
        [Required]
        public DateTime end { get; set; }
    }
}
 