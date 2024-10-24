namespace StaffManagement.Persistence.Repositories.Employee
{
    public class EmployeeWriteRepository : WriteRepository<Domain.Entities.Employee>, IEmployeeWriteRepository
    {
        public EmployeeWriteRepository(AppDbContext context) : base(context) { }
    }
}
