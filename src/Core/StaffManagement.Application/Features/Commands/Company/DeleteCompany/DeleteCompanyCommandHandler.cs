namespace StaffManagement.Application.Features.Commands.Company.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest, Response<DeleteCompanyCommandResponse>>
    {
        private readonly ICompanyReadRepository _readRepository;
        private readonly ICompanyWriteRepository _writeRepository;

        public DeleteCompanyCommandHandler(ICompanyReadRepository readRepository, ICompanyWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<DeleteCompanyCommandResponse>> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await _readRepository.GetByIdAsync(request.Id);

            if (company == null) return ResponseHelper.CreateErrorResponse<DeleteCompanyCommandResponse>("Company not found", StatusCode.NotFound);

            company.IsDeleted = true;

            await _writeRepository.SaveAsync();

            return new Response<DeleteCompanyCommandResponse> { Status = StatusCode.NoContent };
        }
    }
}
