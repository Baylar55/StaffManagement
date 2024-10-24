namespace StaffManagement.Application.Features.Queries.Company.GetAll
{
    public record GetAllCompanyQueryRequest(PagingParams Params) : IRequest<PaginatedResponse<GetAllCompaniesQueryResponse>>;
}
