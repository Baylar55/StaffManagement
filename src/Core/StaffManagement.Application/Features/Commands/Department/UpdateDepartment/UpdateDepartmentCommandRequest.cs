namespace StaffManagement.Application.Features.Commands.Department.UpdateDepartment
{
    public record UpdateDepartmentCommandRequest(int Id, string Name, int CompanyId) : IRequest<Response<UpdateDepartmentCommandResponse>>;
}
