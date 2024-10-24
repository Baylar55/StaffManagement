namespace StaffManagement.Application.Features.Queries.Company.GetById
{
    public class GetCompanyByIdQueryRequestValidator : AbstractValidator<GetCompanyByIdQueryRequest>
    {
        public GetCompanyByIdQueryRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
