namespace StaffManagement.Application.Features.Commands.Company.UpdateCompany
{
    public record UpdateCompanyCommandRequest(int Id, string Name) : IRequest<Response<UpdateCompanyCommandResponse>>;
}
