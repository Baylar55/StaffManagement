namespace StaffManagement.Application.Features.Commands.Employee.DeleteEmployee
{
    public record DeleteEmployeeCommandRequest(int Id) : IRequest<Response<DeleteEmployeeCommandResponse>>;
}
