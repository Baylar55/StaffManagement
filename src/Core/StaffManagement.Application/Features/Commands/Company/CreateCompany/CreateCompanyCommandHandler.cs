namespace StaffManagement.Application.Features.Commands.Company.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, Response<CreateCompanyCommandResponse>>
    {
        private readonly ICompanyWriteRepository _writeRepository;
        private readonly ICompanyReadRepository _readRepository;

        public CreateCompanyCommandHandler(ICompanyWriteRepository writeRepository, ICompanyReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Response<CreateCompanyCommandResponse>> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var isExist = await IsExist(request.Name, cancellationToken);

            if (isExist) return ResponseHelper.CreateErrorResponse<CreateCompanyCommandResponse>("Company already exist", StatusCode.Conflict);

            var company = new Domain.Entities.Company { Name = request.Name };

            await _writeRepository.AddAsync(company);

            await _writeRepository.SaveAsync();

            return new Response<CreateCompanyCommandResponse> { IsSuccessful = true, Status = StatusCode.Created };
        }

        private async Task<bool> IsExist(string name, CancellationToken cancellationToken)
        {
            return await _readRepository.GetWhere(x => x.Name == name).AnyAsync(cancellationToken);
        }
    }
}
