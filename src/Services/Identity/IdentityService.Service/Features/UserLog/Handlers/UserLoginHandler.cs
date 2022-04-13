using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityService.Application.Domain;
using IdentityService.Application.Features.UserLog.Querys;
using IdentityService.Application.Repositories;
using MediatR;

namespace IdentityService.Application.Features.UserLog.Handlers
{
    public class UserLoginHandler : IRequestHandler<GetLoginUserQuery, User>
    {
        private readonly ILoginRepository _repository;

        public UserLoginHandler(ILoginRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<User> Handle(GetLoginUserQuery request, CancellationToken cancellationToken)
        {
            return await _repository.CheckIfValidUserAsync(request.UserId, request.Password);
        }
    }
}
