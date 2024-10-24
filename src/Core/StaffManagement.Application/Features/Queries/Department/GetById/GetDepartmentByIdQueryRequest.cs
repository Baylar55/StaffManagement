namespace StaffManagement.Application.Features.Queries.Department.GetById
{
    public record GetDepartmentByIdQueryRequest(int Id) : IRequest<Response<GetDepartmentByIdQueryResponse>>;
}
