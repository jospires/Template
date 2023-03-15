using Template.Data.Models;

namespace Template.Services.Interfaces
{
    public interface IProjectsService
    {
        Task<Project> Get(int id);
        Task<Tuple<IEnumerable<Project>, int>> List(int skip, int take, string sortBy, string sortOrder);
        Task<Project> Create(Project project);
        Task<Project> Update(Project project);
        Task Delete(int id);
    }
}