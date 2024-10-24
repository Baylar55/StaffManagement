namespace StaffManagement.Application.Features.Queries.Department.GetAll
{
    public record GetAllDepartmentsQueryRequest(PagingParams Params) : IRequest<PaginatedResponse<GetAllDepartmentsQueryResponse>>;
}
