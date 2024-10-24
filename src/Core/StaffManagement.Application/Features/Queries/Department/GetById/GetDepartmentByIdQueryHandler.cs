namespace StaffManagement.Application.Features.Queries.Department.GetById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQueryRequest, Response<GetDepartmentByIdQueryResponse>>
    {
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly IMapper _mapper;

        public GetDepartmentByIdQueryHandler(IDepartmentReadRepository departmentReadRepository, IMapper mapper)
        {
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetDepartmentByIdQueryResponse>> Handle(GetDepartmentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentReadRepository.GetWhere(x => x.Id == request.Id).Include(x => x.Company).FirstOrDefaultAsync(cancellationToken);

            if (department == null) return ResponseHelper.CreateErrorResponse<GetDepartmentByIdQueryResponse>("Department not found", StatusCode.NotFound);

            var mappedDepartment = _mapper.Map<GetDepartmentByIdQueryResponse>(department);

            return new Response<GetDepartmentByIdQueryResponse> { Data = mappedDepartment };
        }
    }
}
