using System;
using Attendance.Application.Features.Attendance.Commands;
using FluentValidation;

namespace Attendance.Application.Features.Validators
{
    public class PunchInCommandValidator : AbstractValidator<PunchInCommand>
    {
        public PunchInCommandValidator()
        {
            RuleFor(i => i.EmployeeId)
                .NotEmpty().WithMessage("EmployeeId is required")
                .NotNull()
                .GreaterThan(0).WithMessage("EmployeeId must be greter then 0");
        }
    }
}
