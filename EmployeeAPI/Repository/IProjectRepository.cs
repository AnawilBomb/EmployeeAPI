using EmployeeAPI.Entities;

namespace EmployeeAPI.Repository
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectDetails();
        void PushProject(Project project);
        void DeleteProject(int id);
        void UpdateProject(Project project);
        Task<List<object>> SearchProject(string? search);
    }
}
