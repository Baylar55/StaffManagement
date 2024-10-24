namespace StaffManagement.Application.Features.Commands.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, Response<DeleteEmployeeCommandResponse>>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        private readonly IMapper _mapper;

        public DeleteEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository ,IEmployeeWriteRepository employeeWriteRepository,IMapper mapper)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _mapper = mapper;
        }

        public async Task<Response<DeleteEmployeeCommandResponse>> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.Id);

            if (employee == null) return ResponseHelper.CreateErrorResponse<DeleteEmployeeCommandResponse>("Employee not found", StatusCode.NotFound);

            employee.IsDeleted = true;

            await _employeeWriteRepository.SaveAsync();

            return new Response<DeleteEmployeeCommandResponse> { Status = StatusCode.NoContent };
        }
    }
}
