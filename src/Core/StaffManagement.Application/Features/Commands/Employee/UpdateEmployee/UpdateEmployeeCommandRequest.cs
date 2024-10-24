namespace StaffManagement.Application.Features.Commands.Employee.UpdateEmployee
{
    public record UpdateEmployeeCommandRequest(int Id, string Name, string Surname, DateTime BirthDate, int DepartmentId) : IRequest<Response<UpdateEmployeeCommandResponse>>;
}
