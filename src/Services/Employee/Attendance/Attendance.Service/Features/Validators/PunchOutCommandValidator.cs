using System;
using Attendance.Application.Features.Attendance.Commands;
using FluentValidation;

namespace Attendance.Application.Features.Validators
{
    public class PunchOutCommandValidator : AbstractValidator<PunchOutCommand>
    {
        public PunchOutCommandValidator()
        {
            RuleFor(i => i.EmployeeId)
                .NotEmpty().WithMessage("Employeeid is required")
                .NotNull()
                .GreaterThan(0).WithMessage("Employeeid must be greter then 0");
        }
    }
}
