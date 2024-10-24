using StaffManagement.Domain.Entities.Base;

namespace StaffManagement.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
