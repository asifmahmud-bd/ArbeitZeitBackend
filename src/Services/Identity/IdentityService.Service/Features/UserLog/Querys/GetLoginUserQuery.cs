using IdentityService.Application.Domain;
using MediatR;

namespace IdentityService.Application.Features.UserLog.Querys
{
    public class GetLoginUserQuery : IRequest<User>
    {
        public string UserId { get;}
        public string Password { get; }

        public GetLoginUserQuery(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }
    }
}
