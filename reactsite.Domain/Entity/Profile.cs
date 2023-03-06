using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace reactsite.Domain.Entity
{
    public class Profile
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public short Age { get; set; }
        public long UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
