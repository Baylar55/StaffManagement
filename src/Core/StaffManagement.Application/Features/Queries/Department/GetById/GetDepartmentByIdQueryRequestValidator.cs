namespace StaffManagement.Application.Features.Queries.Department.GetById
{
    public class GetDepartmentByIdQueryRequestValidator : AbstractValidator<GetDepartmentByIdQueryRequest>
    {
        public GetDepartmentByIdQueryRequestValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("Id is required.");
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
