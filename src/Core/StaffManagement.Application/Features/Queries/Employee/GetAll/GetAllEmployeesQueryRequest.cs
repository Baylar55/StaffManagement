namespace StaffManagement.Application.Features.Queries.Employee.GetAll
{
    public record GetAllEmployeesQueryRequest(EmployeeFilterParams FilterParams, PagingParams PagingParams) : IRequest<PaginatedResponse<GetAllEmployeesQueryResponse>>;
}
