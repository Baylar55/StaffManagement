namespace StaffManagement.Application.Features.Queries.Company.GetById
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQueryRequest, Response<GetCompanyByIdQueryResponse>>
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly IMapper _mapper;

        public GetCompanyByIdQueryHandler(ICompanyReadRepository companyReadRepository, IMapper mapper)
        {
            _companyReadRepository = companyReadRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetCompanyByIdQueryResponse>> Handle(GetCompanyByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var company = await _companyReadRepository.GetByIdAsync(request.Id, false);

            if (company == null) return ResponseHelper.CreateErrorResponse<GetCompanyByIdQueryResponse>("Company not found", StatusCode.NotFound);

            var mappedCompany = _mapper.Map<GetCompanyByIdQueryResponse>(company);

            return new Response<GetCompanyByIdQueryResponse>()
            {
                Data = mappedCompany
            };
        }
    }
}
