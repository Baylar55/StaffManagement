namespace StaffManagement.Application.Features.Queries.Company.GetAll
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, PaginatedResponse<GetAllCompaniesQueryResponse>>
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly IMapper _mapper;

        public GetAllCompaniesQueryHandler(ICompanyReadRepository companyReadRepository, IMapper mapper)
        {
            _companyReadRepository = companyReadRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<GetAllCompaniesQueryResponse>> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = await _companyReadRepository.Table.CountAsync(cancellationToken);

            var companies = await _companyReadRepository.GetAll(false)
                .Skip((request.Params.PageIndex - 1) * request.Params.PageSize)
                .Take(request.Params.PageSize)
                .ToListAsync(cancellationToken);

            var mappedCompanies = _mapper.Map<IReadOnlyList<GetAllCompaniesQueryResponse>>(companies);

            return new PaginatedResponse<GetAllCompaniesQueryResponse>(mappedCompanies, totalCount, request.Params.PageIndex, request.Params.PageSize);
        }
    }
}
