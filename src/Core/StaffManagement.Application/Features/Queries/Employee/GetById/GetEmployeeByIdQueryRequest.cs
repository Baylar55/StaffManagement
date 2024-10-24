namespace StaffManagement.Application.Features.Queries.Employee.GetById
{
    public record GetEmployeeByIdQueryRequest(int Id) : IRequest<Response<GetEmployeeByIdQueryResponse>>;
}
