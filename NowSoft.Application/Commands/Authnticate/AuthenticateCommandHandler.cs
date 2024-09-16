using MediatR;
using Microsoft.EntityFrameworkCore;
using NowSoft.Application.DTOs;
using NowSoft.Domain.Entities;
using NowSoft.Infrastructure.Data;
using NowSoft.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowSoft.Application.Commands.Authnticate
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthenticateCommandHandler(ApplicationDbContext context, IJwtTokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username, cancellationToken);
            if (user == null || request.Password != user.PasswordHash)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var loginAttempt = new LoginAttempt
            {
                UserId = user.Id,
                LoginTime = DateTime.UtcNow,
                IpAddress = request.IpAddress,
                Device = request.Device,
                Browser = request.Browser
            };
            _context.LoginAttempts.Add(loginAttempt);

            if (user.Balance == 0)
            {
                user.Balance = 5.0m;
                _context.Users.Update(user);
            }

            await _context.SaveChangesAsync(cancellationToken);

            var token = _tokenGenerator.GenerateToken(user);
            return new AuthenticateResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = token
            };
        }
    }
}
