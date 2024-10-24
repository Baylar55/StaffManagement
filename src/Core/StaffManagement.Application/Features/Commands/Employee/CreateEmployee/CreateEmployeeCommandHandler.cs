namespace StaffManagement.Application.Features.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, Response<CreateEmployeeCommandResponse>>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IDepartmentReadRepository departmentReadRepository, IMapper mapper)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateEmployeeCommandResponse>> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentReadRepository.GetByIdAsync(request.DepartmentId);

            if (department == null) return ResponseHelper.CreateErrorResponse<CreateEmployeeCommandResponse>("Department not found", StatusCode.NotFound);

            var employee = _mapper.Map<Domain.Entities.Employee>(request);

            await _employeeWriteRepository.AddAsync(employee);

            await _employeeWriteRepository.SaveAsync();

            return new Response<CreateEmployeeCommandResponse> { Status = StatusCode.Created };
        }
    }
}
