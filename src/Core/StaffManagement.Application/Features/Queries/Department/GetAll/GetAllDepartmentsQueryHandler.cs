namespace StaffManagement.Application.Features.Queries.Department.GetAll
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQueryRequest, PaginatedResponse<GetAllDepartmentsQueryResponse>>
    {
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly IMapper _mapper;

        public GetAllDepartmentsQueryHandler(IDepartmentReadRepository departmentReadRepository, IMapper mapper)
        {
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<GetAllDepartmentsQueryResponse>> Handle(GetAllDepartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = await _departmentReadRepository.Table.CountAsync(cancellationToken);

            var departments = await _departmentReadRepository.GetAll(false).Include(x => x.Company)
                .Skip((request.Params.PageIndex - 1) * request.Params.PageSize)
                .Take(request.Params.PageSize)
                .ToListAsync(cancellationToken);

            var mappedDepartments = _mapper.Map<IReadOnlyList<GetAllDepartmentsQueryResponse>>(departments);

            return new PaginatedResponse<GetAllDepartmentsQueryResponse>(mappedDepartments, totalCount, request.Params.PageIndex, request.Params.PageSize);
        }
    }
}
