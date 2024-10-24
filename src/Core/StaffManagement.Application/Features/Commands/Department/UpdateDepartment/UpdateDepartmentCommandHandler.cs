namespace StaffManagement.Application.Features.Commands.Department.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, Response<UpdateDepartmentCommandResponse>>
    {
        private readonly IDepartmentWriteRepository _departmentWriteRepository;
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly IDepartmentReadRepository _readRepository;

        public UpdateDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository departmentWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _companyReadRepository = companyReadRepository;
            _readRepository = readRepository;
        }

        public async Task<Response<UpdateDepartmentCommandResponse>> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var department = await _readRepository.GetByIdAsync(request.Id);

            if (department == null) return ResponseHelper.CreateErrorResponse<UpdateDepartmentCommandResponse>("Department not found", StatusCode.NotFound);

            var isExist = await IsExist(request.Name, request.Id, cancellationToken);

            if (isExist) return ResponseHelper.CreateErrorResponse<UpdateDepartmentCommandResponse>("Department already exist", StatusCode.Conflict);

            var company = await _companyReadRepository.GetByIdAsync(request.CompanyId);

            if (company == null) return ResponseHelper.CreateErrorResponse<UpdateDepartmentCommandResponse>("Company not found", StatusCode.NotFound);

            department.Name = request.Name;
            department.CompanyId = request.CompanyId;

            await _departmentWriteRepository.SaveAsync();

            return new Response<UpdateDepartmentCommandResponse> { Status = StatusCode.NoContent };
        }

        private async Task<bool> IsExist(string name, int id, CancellationToken cancellationToken)
        {
            return await _readRepository.GetWhere(x => x.Name == name && x.Id != id).AnyAsync(cancellationToken);
        }
    }
}
