namespace StaffManagement.Application.Features.Commands.Company.CreateCompany
{
    public class CreateCompanyCommandRequestValidator : AbstractValidator<CreateCompanyCommandRequest>
    {
        public CreateCompanyCommandRequestValidator()
        {

            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}
