using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowSoft.Domain.Entities
{
    public class LoginAttempt
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public string IpAddress { get; set; }
        public string Device { get; set; }
        public string Browser { get; set; }
    }
}
