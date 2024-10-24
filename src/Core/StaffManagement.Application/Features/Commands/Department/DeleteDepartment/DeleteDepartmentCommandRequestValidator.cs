namespace StaffManagement.Application.Features.Commands.Department.DeleteDepartment
{
    public class DeleteDepartmentCommandRequestValidator : AbstractValidator<DeleteDepartmentCommandRequest>
    {
        public DeleteDepartmentCommandRequestValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("Id is required.");
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
