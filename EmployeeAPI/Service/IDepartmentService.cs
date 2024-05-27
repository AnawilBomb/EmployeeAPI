using EmployeeAPI.Entities;

namespace EmployeeAPI.Service
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartmentDetails();
        void PushDepartment(Department department);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
        Task<List<object>> SearchDepartment(string search);
    }
}
