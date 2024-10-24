namespace StaffManagement.Application.Features.Commands.Department.CreateDepartment
{
    public class CreateDepartmentCommandRequestValidator : AbstractValidator<CreateDepartmentCommandRequest>
    {
        public CreateDepartmentCommandRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(p => p.Name).MaximumLength(70).WithMessage("Name must not exceed 70 characters.");
            RuleFor(p => p.CompanyId).NotNull().NotEmpty().WithMessage("Id is required.");
            RuleFor(p => p.CompanyId).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
