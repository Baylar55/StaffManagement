namespace StaffManagement.Application.Features.Commands.Employee.CreateEmployee
{
    public record CreateEmployeeCommandRequest(string Name, string Surname, DateTime BirthDate, int DepartmentId) : IRequest<Response<CreateEmployeeCommandResponse>>;
}
