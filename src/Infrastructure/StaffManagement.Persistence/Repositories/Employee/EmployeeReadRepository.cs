namespace StaffManagement.Persistence.Repositories.Employee
{
    public class EmployeeReadRepository : ReadRepository<Domain.Entities.Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(AppDbContext context) : base(context) { }
    }
}
