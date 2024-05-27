namespace EmployeeAPI.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ManagerID { get; set; } 
    }
}
