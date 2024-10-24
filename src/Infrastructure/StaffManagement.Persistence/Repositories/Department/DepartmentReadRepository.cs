namespace StaffManagement.Persistence.Repositories.Department
{
    public class DepartmentReadRepository : ReadRepository<Domain.Entities.Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(AppDbContext context) : base(context) { }
    }
}
