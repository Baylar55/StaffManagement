namespace StaffManagement.Application.Features.Commands.Company.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, Response<UpdateCompanyCommandResponse>>
    {
        private readonly ICompanyWriteRepository _companyWriteRepository;
        private readonly ICompanyReadRepository _companyReadRepository;

        public UpdateCompanyCommandHandler(ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            _companyWriteRepository = companyWriteRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<Response<UpdateCompanyCommandResponse>> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var isExist = await IsExist(request.Name, request.Id, cancellationToken);

            if (isExist) return ResponseHelper.CreateErrorResponse<UpdateCompanyCommandResponse>("Company already exist", StatusCode.Conflict);

            var company = await _companyReadRepository.GetByIdAsync(request.Id);

            if (company == null) return ResponseHelper.CreateErrorResponse<UpdateCompanyCommandResponse>("Company not found", StatusCode.NotFound);

            company.Name = request.Name;

            await _companyWriteRepository.SaveAsync();

            return new Response<UpdateCompanyCommandResponse> { Status = StatusCode.NoContent };
        }

        private async Task<bool> IsExist(string name, int id, CancellationToken cancellationToken)
        {
            return await _companyReadRepository.GetWhere(x => x.Name == name && x.Id != id).AnyAsync(cancellationToken);
        }
    }
}
