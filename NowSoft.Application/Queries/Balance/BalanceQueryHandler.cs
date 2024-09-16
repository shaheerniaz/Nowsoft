using MediatR;
using Microsoft.EntityFrameworkCore;
using NowSoft.Application.DTOs;
using NowSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowSoft.Application.Queries.Balance
{
    public class GetBalanceQueryHandler : IRequestHandler<BalanceQuery, BalanceResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetBalanceQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BalanceResponse> Handle(BalanceQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username, cancellationToken);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }
            return new BalanceResponse { Balance = user.Balance };
        }
    }
}
