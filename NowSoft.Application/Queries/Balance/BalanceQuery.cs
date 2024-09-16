using MediatR;
using NowSoft.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowSoft.Application.Queries.Balance
{
    public class BalanceQuery : IRequest<BalanceResponse>
    {
        public string Username { get; set; }
    }
}
