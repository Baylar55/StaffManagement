namespace StaffManagement.Application.Features.Queries.Company.GetById
{
    public record GetCompanyByIdQueryRequest(int Id) : IRequest<Response<GetCompanyByIdQueryResponse>>;
}
