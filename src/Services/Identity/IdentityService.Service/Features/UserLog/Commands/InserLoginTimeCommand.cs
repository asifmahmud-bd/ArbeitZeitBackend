using System;
using MediatR;

namespace IdentityService.Application.Features.UserLog.Commands
{
    public class InserLoginTimeCommand : IRequest<bool>
    {
        public int UserId { get; }

        public InserLoginTimeCommand(int userId)
        {
            UserId = userId;
        }
    }
}
