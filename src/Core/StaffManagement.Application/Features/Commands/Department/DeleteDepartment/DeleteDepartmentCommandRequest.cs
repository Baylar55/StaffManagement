namespace StaffManagement.Application.Features.Commands.Department.DeleteDepartment
{
    public record DeleteDepartmentCommandRequest(int Id) : IRequest<Response<DeleteDepartmentCommandResponse>>;
}
