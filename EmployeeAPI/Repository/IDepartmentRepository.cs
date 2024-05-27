
using EmployeeAPI.Entities;

namespace EmployeeAPI.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentDetails();
        void PushDepartment(Department department);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
        Task<List<object>> SearchDepartment(string? search);
    }
}
