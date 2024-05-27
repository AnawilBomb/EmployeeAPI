using EmployeeAPI.Entities;
using EmployeeAPI.Repository;

namespace EmployeeAPI.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<Project>> GetProjectDetails()
        {
            var result = await _projectRepository.GetProjectDetails();
            return result;
        }

        public void PushProject(Project project)
        {
            _projectRepository.PushProject(project);
        }
        public void DeleteProject(int id)
        {
            _projectRepository.DeleteProject(id);
        }
        public void UpdateProject(Project project)
        {
            _projectRepository.UpdateProject(project);
        }
        public async Task<List<object>> SearchProject(string search)
        {
            var result = await _projectRepository.SearchProject(search);
            return result;
        }
    }
}
