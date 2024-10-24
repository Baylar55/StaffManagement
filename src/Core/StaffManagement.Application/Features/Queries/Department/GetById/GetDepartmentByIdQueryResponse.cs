namespace StaffManagement.Application.Features.Queries.Department.GetById
{
    public record GetDepartmentByIdQueryResponse(int Id, string Name, int CompanyId, DateTime CreatedDate, DateTime? ModifiedDate);
}
