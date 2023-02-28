using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Domain.Helpers
{
    public class AuthOptions
    {
        public string Issuer { get; set; } //Тот кто сгенерировал токен 
        public string Audience { get; set; }//Для кого токен
        public string Secret { get; set; }// Секретная строка
        public int TokenLifetime { get; set; }// секунды жизни токена
        public SymmetricSecurityKey GetSemmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
