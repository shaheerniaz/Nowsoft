using MediatR;
using Microsoft.AspNetCore.Mvc;
using NowSoft.Application.Commands.Authnticate;
using NowSoft.Application.Commands.Signup;
using NowSoft.Application.Queries.Balance;
using NowSoft.Infrastructure.Interfaces;

namespace NowSoft.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public UsersController(IMediator mediator, IJwtTokenGenerator tokenGenerator)
        {
            _mediator = mediator;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("auth/balance")]
        public async Task<IActionResult> GetBalance([FromBody] string token)
        {
            var username = _tokenGenerator.GetUsernameFromToken(token); // This method should be implemented in JwtTokenGenerator
            var response = await _mediator.Send(new BalanceQuery { Username = username });
            return Ok(response);
        }
    }
}
