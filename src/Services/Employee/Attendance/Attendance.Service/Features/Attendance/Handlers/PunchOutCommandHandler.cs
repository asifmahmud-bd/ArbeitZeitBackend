using System;
using System.Threading;
using System.Threading.Tasks;
using Attendance.Application.Features.Attendance.Commands;
using Attendance.Application.Repositories;
using MediatR;

namespace Attendance.Application.Features.Attendance.Handlers
{
    public class PunchOutCommandHandler : IRequestHandler<PunchOutCommand, bool>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public PunchOutCommandHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(PunchOutCommand request, CancellationToken cancellationToken)
        {
            return await _attendanceRepository.UpdateAttendanceOut(request.EmployeeId);
        }
    }
}
