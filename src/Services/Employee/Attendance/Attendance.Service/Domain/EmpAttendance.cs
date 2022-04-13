using System;
using MediatR;

namespace Attendance.Application.Domain
{
    public class EmployeeAttendance
    {
        public int EmployeeId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }
    }
}
