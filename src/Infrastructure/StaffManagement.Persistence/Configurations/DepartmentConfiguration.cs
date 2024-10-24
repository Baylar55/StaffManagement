using StaffManagement.Persistence.Configurations.Common;

namespace StaffManagement.Persistence.Configurations
{
    public class DepartmentConfiguration : BaseConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.Company)
                   .WithMany(x => x.Departments)
                   .HasForeignKey(x => x.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
