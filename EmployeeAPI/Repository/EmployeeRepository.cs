using EmployeeAPI.Data;
using EmployeeAPI.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<object>> GetEmployeeDetails()
        {
            var result = await (from emp in _context.Employees
                               join dept in _context.Departments on emp.DepartmentID equals dept.DepartmentID
                               join proj in _context.Projects on emp.DepartmentID equals proj.DepartmentID
                               select new 
                               {
                                   emp.FirstName,
                                   emp.LastName,
                                   emp.Gender,
                                   emp.Email,
                                   emp.JobTitle,
                                   DepartmentName = dept.Name ,
                                   proj.ProjectName
                               }).ToListAsync<object>();
            return result;
        }

        public void PushEmployee(Employee employee)
        {
            if (employee.FirstName == null || string.IsNullOrEmpty(employee.FirstName))
            {
                return;
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employeeToDelete = _context.Employees.Find(id);
            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.Find(employee.EmployeeId);
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Email = employee.Email;
                existingEmployee.DepartmentID = employee.DepartmentID;
                existingEmployee.JobTitle = employee.JobTitle;

                _context.SaveChanges();
            }
        }
        public async Task<List<object>> SearchEmployee(string? search)
        {
            var result = await (from emp in _context.Employees
                                join dept in _context.Departments on emp.DepartmentID equals dept.DepartmentID
                                join proj in _context.Projects on emp.DepartmentID equals proj.DepartmentID
                                where string.IsNullOrEmpty(search)
                               || emp.FirstName.Contains(search)
                               || emp.LastName.Contains(search)
                               || emp.Gender.Contains(search)
                               || emp.JobTitle.Contains(search)
                                select new
                                {
                                    emp.FirstName,
                                    emp.LastName,
                                    emp.Gender,
                                    emp.Email,
                                    emp.JobTitle,
                                    DepartmentName = dept.Name,
                                    proj.ProjectName,
                                }).ToListAsync<object>();
            return result;
        }
    }
}
