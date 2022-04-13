using System;
using System.Threading.Tasks;
using IdentityService.Api.Entities;
using IdentityService.Api.Repositories.Authentication;
using IdentityService.Application.Features.UserLog.Commands;
using IdentityService.Application.Features.UserLog.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityService.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginController> _logger;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public LoginController(ILogger<LoginController> logger, IJwtAuthenticationManager jwtAuthenticationManager, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _jwtAuthenticationManager = jwtAuthenticationManager ?? throw new ArgumentNullException(nameof(jwtAuthenticationManager));
        }

        //[AllowAnonymous]
        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] LoginCredential credential)
        {
            var query = new GetLoginUserQuery(credential.Username, credential.Password);
            var user = await _mediator.Send(query);

            if(user == null)
            {
                return NotFound();
            }

            var token = _jwtAuthenticationManager.Authenticate(credential, user);

            if(token != null)
            {
                var command = new InserLoginTimeCommand(user.EmployeeId);
               await _mediator.Send(command);

               return Ok(token);
            }

            return Unauthorized();
        }

        //[AllowAnonymous]
        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] LoginCredential credential)
        {
            var query = new GetLoginUserQuery(credential.Username, credential.Password);

            var user = await _mediator.Send(query);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
