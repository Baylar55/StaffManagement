namespace StaffManagement.Persistence.Configurations.Common
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
