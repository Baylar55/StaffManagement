using StaffManagement.Domain.Entities.Base;

namespace StaffManagement.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
