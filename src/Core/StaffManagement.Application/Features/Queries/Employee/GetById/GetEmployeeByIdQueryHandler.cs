namespace StaffManagement.Application.Features.Queries.Employee.GetById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQueryRequest, Response<GetEmployeeByIdQueryResponse>>
    {
        private readonly IEmployeeReadRepository _readRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetEmployeeByIdQueryResponse>> Handle(GetEmployeeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var employee = await _readRepository.GetWhere(x => x.Id == request.Id, false)
                                                .Include(x => x.Department)
                                                .ThenInclude(x => x.Company)
                                                .FirstOrDefaultAsync(cancellationToken);

            if (employee == null) return ResponseHelper.CreateErrorResponse<GetEmployeeByIdQueryResponse>("Employee not found", StatusCode.NotFound);

            var mappedEmployee = new GetEmployeeByIdQueryResponse(employee.Id, employee.Name, employee.Surname, employee.Department.Name,
                employee.Department.Company.Name, employee.CreatedDate, employee.ModifiedDate);

            return new Response<GetEmployeeByIdQueryResponse>() { Data = mappedEmployee };
        }
    }
}
