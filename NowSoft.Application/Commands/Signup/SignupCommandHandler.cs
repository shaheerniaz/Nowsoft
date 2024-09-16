using MediatR;
using NowSoft.Domain.Entities;
using NowSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowSoft.Application.Commands.Signup
{
    public class SignupCommandHandler : IRequestHandler<SignupCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public SignupCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Device = request.Device,
                IpAddress = request.IpAddress,
                Balance = 0
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
