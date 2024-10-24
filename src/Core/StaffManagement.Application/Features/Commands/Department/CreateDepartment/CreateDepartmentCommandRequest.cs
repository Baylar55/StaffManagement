namespace StaffManagement.Application.Features.Commands.Department.CreateDepartment
{
    public record CreateDepartmentCommandRequest(string Name, int CompanyId) : IRequest<Response<CreateDepartmentCommandResponse>>;
}
