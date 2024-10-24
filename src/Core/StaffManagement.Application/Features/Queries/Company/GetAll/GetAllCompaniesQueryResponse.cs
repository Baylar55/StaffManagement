namespace StaffManagement.Application.Features.Queries.Company.GetAll
{
    public record GetAllCompaniesQueryResponse(int Id, string Name, DateTime CreatedDate, DateTime? ModifiedDate);
}
