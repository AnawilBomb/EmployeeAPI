namespace EmployeeAPI.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } // Allow null
        public string? Email { get; set; } // Allow null
        public string? Gender { get; set; } // Allow null
        public int DepartmentID { get; set; }
        public string? JobTitle { get; set; } // Allow null
    }
}
