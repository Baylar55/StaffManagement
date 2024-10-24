namespace StaffManagement.Application.RequestParameters
{
    public class EmployeeFilterParams
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? DepartmentId { get; set; }
    }
}
