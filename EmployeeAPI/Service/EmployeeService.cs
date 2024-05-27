using EmployeeAPI.Entities;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        { 
            _employeeRepository = employeeRepository;
        }

        public async Task<List<object>> GetEmployeeDetails()
        {
            var result = await _employeeRepository.GetEmployeeDetails();
            return result;
        }

        public void PushEmployee(Employee employee)
        {
            _employeeRepository.PushEmployee(employee);
        }
        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
        public async Task<List<object>> SearchEmployee(string search)
        {
            var result = await _employeeRepository.SearchEmployee(search);
            return result;
        }
    }
}
