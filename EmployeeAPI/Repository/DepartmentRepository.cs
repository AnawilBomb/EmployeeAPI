using EmployeeAPI.Data;
using EmployeeAPI.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeAPI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> GetDepartmentDetails()
        {
            var data = await _context.Departments.ToListAsync();
            return data;
        }

        public void PushDepartment(Department department)
        {
            if (department.Name == null || string.IsNullOrEmpty(department.Name))
            {
                return;
            }
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var departmentToDelete = _context.Departments.Find(id);
            if (departmentToDelete != null)
            {
                _context.Departments.Remove(departmentToDelete);
                _context.SaveChanges();
            }
        }

        public void UpdateDepartment(Department department)
        {
            var existingDepartment = _context.Departments.Find(department.DepartmentID);
            {
                existingDepartment.Name = department.Name;
                existingDepartment.ManagerID = department.ManagerID;
                _context.SaveChanges();
            }
        }
        public async Task<List<object>> SearchDepartment(string? search)
        {
            var result = await (from dept in _context.Departments
                                join emp in _context.Employees on dept.DepartmentID equals emp.DepartmentID
                                join proj in _context.Projects on dept.DepartmentID equals proj.DepartmentID
                                where string.IsNullOrEmpty(search)
                               || dept.Name.Contains(search)
                                select new
                                {
                                    DepartmentName = dept.Name,
                                    emp.FirstName,
                                    emp.LastName,
                                    emp.Gender,
                                    emp.Email,
                                    emp.JobTitle,
                                    proj.ProjectName,
                                    dept.ManagerID
                                }).ToListAsync<object>();
            return result;
        }
    }
}
