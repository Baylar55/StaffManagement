namespace StaffManagement.Application.Features.Queries.Employee.GetAll
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQueryRequest, PaginatedResponse<GetAllEmployeesQueryResponse>>
    {
        private readonly IEmployeeReadRepository _readRepository;

        public GetAllEmployeesQueryHandler(IEmployeeReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<PaginatedResponse<GetAllEmployeesQueryResponse>> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _readRepository.GetAll(false).Include(x => x.Department).ThenInclude(x => x.Company).AsQueryable();

            query = ApplyFilters(query, request);

            var totalItems = await query.CountAsync(cancellationToken);

            query = ApplyPaging(query, request.PagingParams);

            var employees = await query.ToListAsync(cancellationToken);

            var mappedEmployees = employees.Select(item => new GetAllEmployeesQueryResponse( item.Id, item.Name,
                                                   item.Surname,
                                                   item.Department.Name, 
                                                   item.Department.Company.Name)).ToList();

            return new PaginatedResponse<GetAllEmployeesQueryResponse>(mappedEmployees, totalItems, request.PagingParams.PageIndex, request.PagingParams.PageSize);
        }

        private static IQueryable<Domain.Entities.Employee> ApplyFilters(IQueryable<Domain.Entities.Employee> queryable, GetAllEmployeesQueryRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.FilterParams.Name))
                queryable = queryable.Where(x => x.Name.Contains(request.FilterParams.Name));

            if (!string.IsNullOrWhiteSpace(request.FilterParams.Surname))
                queryable = queryable.Where(x => x.Surname.Contains(request.FilterParams.Surname));

            if (request.FilterParams.DepartmentId.HasValue && request.FilterParams.DepartmentId > 0)
                queryable = queryable.Where(x => x.DepartmentId == request.FilterParams.DepartmentId);

            return queryable;
        }

        private static IQueryable<Domain.Entities.Employee> ApplyPaging(IQueryable<Domain.Entities.Employee> queryable, PagingParams pagingParams)
        {
            return queryable.Skip((pagingParams.PageIndex - 1) * pagingParams.PageSize).Take(pagingParams.PageSize);
        }
    }
}
