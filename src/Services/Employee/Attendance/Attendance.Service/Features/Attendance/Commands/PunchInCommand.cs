using MediatR;

namespace Attendance.Application.Features.Attendance.Commands
{
    public record PunchInCommand :IRequest<bool>
    {
        public int EmployeeId { get; }

        public PunchInCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
