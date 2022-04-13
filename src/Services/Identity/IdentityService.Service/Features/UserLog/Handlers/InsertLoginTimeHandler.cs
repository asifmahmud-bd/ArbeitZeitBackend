using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityService.Application.Features.UserLog.Commands;
using IdentityService.Application.Repositories;
using MediatR;

namespace IdentityService.Application.Features.UserLog.Handlers
{
    public class InsertLoginTimeHandler : IRequestHandler<InserLoginTimeCommand, bool>
    {
        private readonly ILoginRepository _repository;

        public InsertLoginTimeHandler(ILoginRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(InserLoginTimeCommand request, CancellationToken cancellationToken)
        {
            return _repository.CreateLogAsync(request.UserId);
        }
    }
}
