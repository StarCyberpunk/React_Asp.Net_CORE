using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Domain.ViewModels
{
    public class ProfileViewModel
    {
        public long UserId { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Укажите возраст")]
        [Range(0, 100, ErrorMessage = "Диапозон возраста должен быть от 0 до 100")]
        public short Age { get; set; }
        [Required(ErrorMessage = "Укажите адрес")]
        [MinLength(5, ErrorMessage = "Минимальная длина должна быть больше 5 символов")]
        [MaxLength(250, ErrorMessage = "Максимальная длина должна быть 250 символов")]
        public string Address { get; set; }
    }
}
