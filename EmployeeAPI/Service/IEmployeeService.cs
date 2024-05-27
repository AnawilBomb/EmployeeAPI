using EmployeeAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Service
{
    public interface IEmployeeService
    {
        Task<List<object>> GetEmployeeDetails();
        void PushEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
        Task<List<object>> SearchEmployee(string search);
    }
}
