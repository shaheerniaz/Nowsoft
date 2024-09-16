using MediatR;
using NowSoft.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowSoft.Application.Commands.Authnticate
{
    public class AuthenticateCommand : IRequest<AuthenticateResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string Device { get; set; }
        public string Browser { get; set; }
    }
}
