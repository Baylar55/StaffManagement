namespace StaffManagement.Application.Features.Commands.Department.UpdateDepartment
{
    public class UpdateDepartmentCommandRequestValidator : AbstractValidator<UpdateDepartmentCommandRequest>
    {
        public UpdateDepartmentCommandRequestValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("Id is required.");
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(p => p.Name).MaximumLength(70).WithMessage("Name must not exceed 70 characters.");
            RuleFor(p => p.CompanyId).NotNull().NotEmpty().WithMessage("Id is required.");
            RuleFor(p => p.CompanyId).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
