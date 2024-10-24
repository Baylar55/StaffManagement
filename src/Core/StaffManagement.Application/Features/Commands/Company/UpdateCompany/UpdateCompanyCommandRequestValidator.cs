namespace StaffManagement.Application.Features.Commands.Company.UpdateCompany
{
    public class UpdateCompanyCommandRequestValidator : AbstractValidator<UpdateCompanyCommandRequest>
    {
        public UpdateCompanyCommandRequestValidator()
        {
            RuleFor(x => x.Name)
            .NotNull().NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
