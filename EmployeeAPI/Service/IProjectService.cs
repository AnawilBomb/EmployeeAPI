using EmployeeAPI.Entities;

namespace EmployeeAPI.Service
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectDetails();
        void PushProject(Project project);
        void DeleteProject(int id);
        void UpdateProject(Project project);
        Task<List<object>> SearchProject(string search);
    }
}
