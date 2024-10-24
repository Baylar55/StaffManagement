namespace StaffManagement.Application.Features.Commands.Company.DeleteCompany
{
    public class DeleteCompanyCommandRequestValidator : AbstractValidator<DeleteCompanyCommandRequest>
    {
        public DeleteCompanyCommandRequestValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull();

            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
