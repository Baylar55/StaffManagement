namespace StaffManagement.Persistence.Repositories.Department
{
    public class DepartmentWriteRepository : WriteRepository<Domain.Entities.Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(AppDbContext context) : base(context) { }
    }
}
