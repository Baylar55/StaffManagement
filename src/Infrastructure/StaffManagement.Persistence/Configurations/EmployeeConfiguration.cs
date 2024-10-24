using StaffManagement.Persistence.Configurations.Common;

namespace StaffManagement.Persistence.Configurations
{
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);

            builder.Property(x => x.BirthDate).IsRequired();

            builder.HasOne(x => x.Department)
                   .WithMany(x => x.Employees)
                   .HasForeignKey(x => x.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
