using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowSoft.Application.Commands.Signup
{
    public class SignupCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
    }
}
