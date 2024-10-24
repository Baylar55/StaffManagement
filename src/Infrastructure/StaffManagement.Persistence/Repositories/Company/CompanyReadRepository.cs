namespace StaffManagement.Persistence.Repositories.Company
{
    public class CompanyReadRepository : ReadRepository<Domain.Entities.Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(AppDbContext context) : base(context) { }
    }
}
