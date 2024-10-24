namespace StaffManagement.Application.Features.Queries.Employee.GetById
{
    public record GetEmployeeByIdQueryResponse(int Id, string Name, string Surname, string DepartmentName, string CompanyName, DateTime CreatedDate, DateTime? ModifiedDate);
}
