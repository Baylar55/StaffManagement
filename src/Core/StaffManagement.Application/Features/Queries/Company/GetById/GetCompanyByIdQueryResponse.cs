namespace StaffManagement.Application.Features.Queries.Company.GetById
{
    public record GetCompanyByIdQueryResponse(int Id, string Name, DateTime CreatedDate, DateTime? ModifiedDate);
}
