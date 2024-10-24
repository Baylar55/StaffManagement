using StaffManagement.Domain.Entities.Base;

namespace StaffManagement.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
