namespace StaffManagement.Application.Features.Queries.Employee.GetById
{
    public class GetEmployeeByIdQueryRequestValidator : AbstractValidator<GetEmployeeByIdQueryRequest>
    {
        public GetEmployeeByIdQueryRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
