using EmployeeAPI.Entities;
using EmployeeAPI.Repository;

namespace EmployeeAPI.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<Department>> GetDepartmentDetails()
        {
            var result = await _departmentRepository.GetDepartmentDetails();
            return result;
        }

        public void PushDepartment(Department department)
        {
            _departmentRepository.PushDepartment(department);
        }
        public void DeleteDepartment(int id)
        {
            _departmentRepository.DeleteDepartment(id);
        }
        public void UpdateDepartment(Department department)
        {
            _departmentRepository.UpdateDepartment(department);
        }
        public async Task<List<object>> SearchDepartment(string search)
        {
            var result = await _departmentRepository.SearchDepartment(search);
            return result;
        }
    }
}
