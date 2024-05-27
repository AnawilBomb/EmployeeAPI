
using EmployeeAPI.Data;
using EmployeeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Project>> GetProjectDetails()
        {
            var data = await _context.Projects.ToListAsync();
            return data;
        }

        public void PushProject(Project project)
        {
            if (project.ProjectName == null || string.IsNullOrEmpty(project.ProjectName))
            {
                return;
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var projectToDelete = _context.Projects.Find(id);
            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                _context.SaveChanges();
            }
        }

        public void UpdateProject(Project project)
        {
            var existingProject = _context.Projects.Find(project.ProjectId);
            {
                existingProject.ProjectId = project.ProjectId;
                existingProject.ProjectName = project.ProjectName;
                existingProject.StartDate = project.StartDate;
                existingProject.EndDate = project.EndDate;
                _context.SaveChanges();
            }
        }
        public async Task<List<object>> SearchProject(string? search)
        {
            var result = await (from proj in _context.Projects
                                join emp in _context.Employees on proj.DepartmentID equals emp.DepartmentID
                                join dept in _context.Departments on proj.DepartmentID equals dept.DepartmentID
                                where string.IsNullOrEmpty(search)
                               || proj.ProjectName.Contains(search)
                                select new
                                {
                                    proj.ProjectName,
                                    emp.FirstName,
                                    emp.LastName,
                                    proj.StartDate,
                                    proj.EndDate
                                }).ToListAsync<object>();
            return result;
        }
    }
}
