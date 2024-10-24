namespace StaffManagement.Application.Features.Queries.Employee.GetAll
{
    public record GetAllEmployeesQueryResponse(int Id, string Name, string Surname, string DepartmentName, string CompanyName);
}
