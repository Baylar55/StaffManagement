namespace StaffManagement.Application.Features.Commands.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommandRequestValidator : AbstractValidator<DeleteEmployeeCommandRequest>
    {
        public DeleteEmployeeCommandRequestValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
