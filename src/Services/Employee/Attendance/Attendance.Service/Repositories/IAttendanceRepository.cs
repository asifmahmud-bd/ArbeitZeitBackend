using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attendance.Application.Domain;

namespace Attendance.Application.Repositories
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<EmployeeAttendance>> GetMonthlyAttendance(int employeeId);
        Task<bool> CreateAttendanceIn(int employeeId);
        Task<bool> UpdateAttendanceOut(int employeeId);
    }
}
