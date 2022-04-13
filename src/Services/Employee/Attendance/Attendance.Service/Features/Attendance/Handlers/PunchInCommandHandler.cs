using System;
using System.Threading;
using System.Threading.Tasks;
using Attendance.Application.Features.Attendance.Commands;
using Attendance.Application.Repositories;
using MediatR;

namespace Attendance.Application.Features.Attendance.Handlers
{
    public class PunchInCommandHandler : IRequestHandler<PunchInCommand, bool>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public PunchInCommandHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository ?? throw new ArgumentNullException(nameof(attendanceRepository));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(PunchInCommand request, CancellationToken cancellationToken)
        {
            return _attendanceRepository.CreateAttendanceIn(request.EmployeeId);
        }
    }
}
