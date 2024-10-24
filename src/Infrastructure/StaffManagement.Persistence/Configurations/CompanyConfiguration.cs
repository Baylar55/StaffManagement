using StaffManagement.Persistence.Configurations.Common;

namespace StaffManagement.Persistence.Configurations
{
    public class CompanyConfiguration : BaseConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);   

            builder.HasMany(x => x.Departments)
                   .WithOne(x => x.Company)
                   .HasForeignKey(x => x.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
