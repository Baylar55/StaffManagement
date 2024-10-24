namespace StaffManagement.Application.Features.Commands.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, Response<UpdateEmployeeCommandResponse>>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IDepartmentReadRepository departmentReadRepository, IMapper mapper)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
        }

        public async Task<Response<UpdateEmployeeCommandResponse>> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.Id);

            if (employee == null) return ResponseHelper.CreateErrorResponse<UpdateEmployeeCommandResponse>("Employee not found", StatusCode.NotFound);

            var department = await _departmentReadRepository.GetByIdAsync(request.DepartmentId);

            if (department == null) return ResponseHelper.CreateErrorResponse<UpdateEmployeeCommandResponse>("Department not found", StatusCode.NotFound);

            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.BirthDate = request.BirthDate;
            employee.DepartmentId = request.DepartmentId;

            await _employeeWriteRepository.SaveAsync();

            return new Response<UpdateEmployeeCommandResponse> { Status = StatusCode.NoContent };
        }
    }
}
