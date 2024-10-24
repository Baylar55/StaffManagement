namespace StaffManagement.Application.Features.Commands.Company.CreateCompany
{
    public class CreateCompanyCommandRequest : IRequest<Response<CreateCompanyCommandResponse>>
    {
        public string Name { get; set; } 
    }
}
