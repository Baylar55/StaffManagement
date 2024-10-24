namespace StaffManagement.Application.Features.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommandRequestValidator : AbstractValidator<CreateEmployeeCommandRequest>
    {
        public CreateEmployeeCommandRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("Name must not exceed 20 characters.");

            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("Surname must not exceed 20 characters.");

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("Birth date is required.")
                .NotNull()
                .Must(BeAtLeast18YearsOld).WithMessage("Employee must be at least 18 years old.");

            RuleFor(p => p.DepartmentId)
                .NotNull().WithMessage("Department id is required.")
                .GreaterThan(0).WithMessage("Department id must be greater than 0.");
        }

        private bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
