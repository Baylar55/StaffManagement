namespace StaffManagement.Application.Features.Commands.Department.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, Response<CreateDepartmentCommandResponse>>
    {
        private readonly IDepartmentWriteRepository _departmentWriteRepository;
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly IDepartmentReadRepository _readRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository departmentWriteRepository, ICompanyReadRepository companyReadRepository, IMapper mapper)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _companyReadRepository = companyReadRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateDepartmentCommandResponse>> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var isExist = await IsExist(request.Name,request.CompanyId, cancellationToken);

            if (isExist) return ResponseHelper.CreateErrorResponse<CreateDepartmentCommandResponse>("Department already exist", StatusCode.Conflict);

            var company = await _companyReadRepository.GetByIdAsync(request.CompanyId);

            if (company == null) return ResponseHelper.CreateErrorResponse<CreateDepartmentCommandResponse>("Company not found", StatusCode.NotFound);

            var department = _mapper.Map<Domain.Entities.Department>(request);

            await _departmentWriteRepository.AddAsync(department);

            await _departmentWriteRepository.SaveAsync();

            return new Response<CreateDepartmentCommandResponse> { IsSuccessful = true, Status = StatusCode.Created };
        }

        private async Task<bool> IsExist(string name, int companyId, CancellationToken cancellationToken)
        {
            return await _readRepository.GetWhere(x => x.Name == name && x.CompanyId == companyId).AnyAsync(cancellationToken);
        }
    }
}
