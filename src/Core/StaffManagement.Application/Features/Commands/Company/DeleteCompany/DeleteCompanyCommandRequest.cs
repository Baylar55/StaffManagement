namespace StaffManagement.Application.Features.Commands.Company.DeleteCompany
{
    public record DeleteCompanyCommandRequest(int Id) : IRequest<Response<DeleteCompanyCommandResponse>>;
}
