using System;
using MediatR;

namespace Attendance.Application.Features.Attendance.Commands
{
    public record PunchOutCommand :IRequest<bool>
    {
        public int EmployeeId { get; }

        public PunchOutCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
