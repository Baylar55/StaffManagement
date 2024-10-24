namespace StaffManagement.Application.Features.Commands.Department.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommandRequest, Response<DeleteDepartmentCommandResponse>>
    {
        private readonly IDepartmentWriteRepository _departmentWriteRepository;
        private readonly IDepartmentReadRepository _departmentReadRepository;

        public DeleteDepartmentCommandHandler(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<Response<DeleteDepartmentCommandResponse>> Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentReadRepository.GetByIdAsync(request.Id);

            if (department == null) return ResponseHelper.CreateErrorResponse<DeleteDepartmentCommandResponse>("Department not found", StatusCode.NotFound);

            department.IsDeleted = true;

            await _departmentWriteRepository.SaveAsync();

            return new Response<DeleteDepartmentCommandResponse> { Status = StatusCode.NoContent };
        }
    }
}
