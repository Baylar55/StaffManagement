namespace StaffManagement.Persistence.Repositories.Company
{
    public class CompanyWriteRepository : WriteRepository<Domain.Entities.Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(AppDbContext context) : base(context) { }
    }
}
