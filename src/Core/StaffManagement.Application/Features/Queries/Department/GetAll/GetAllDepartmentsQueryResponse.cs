namespace StaffManagement.Application.Features.Queries.Department.GetAll
{
    public record GetAllDepartmentsQueryResponse(int Id, string Name, int CompanyId, DateTime CreatedDate, DateTime? ModifiedDate);
}
