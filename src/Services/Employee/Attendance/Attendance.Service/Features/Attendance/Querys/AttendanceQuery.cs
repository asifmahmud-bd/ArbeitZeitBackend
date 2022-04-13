using System;
using System.Collections.Generic;
using Attendance.Application.Domain;
using MediatR;

namespace Attendance.Application.Features.Attendance.Querys
{
    public class AttendanceQuery : IRequest<List<EmployeeAttendance>>
    {
        public int EmployeeId { get; }

        public AttendanceQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }

    
}
