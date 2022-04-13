using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Attendance.Application.Domain;
using Attendance.Application.Features.Attendance.Querys;
using Attendance.Application.Repositories;
using AutoMapper;
using MediatR;

namespace Attendance.Application.Features.Attendance.Handlers
{                                                        
    public class AttendanceQueryHandler : IRequestHandler<AttendanceQuery, List<EmployeeAttendance>>
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceQueryHandler(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository ?? throw new ArgumentNullException(nameof(attendanceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<EmployeeAttendance>> Handle(AttendanceQuery request, CancellationToken cancellationToken)
        {
            var result = await _attendanceRepository.GetMonthlyAttendance(request.EmployeeId);

            return result == null ? null : _mapper.Map<List<EmployeeAttendance>>(result);
        }
    }
}
