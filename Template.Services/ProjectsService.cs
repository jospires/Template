using Template.Data.Models;
using Template.Data.UnitsOfWork;
using Template.Services.Interfaces;

namespace Template.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly ITemplateUnitOfWork _uow;

        public ProjectsService(ITemplateUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Project> Get(int id)
        {
            return await _uow.Projects.GetByIdAsync(id);
        }

        public async Task<Tuple<IEnumerable<Project>, int>> List(int skip, int take, string sortBy, string sortOrder)
        {
            return await _uow.Projects.GetAsync(null, "Team", skip, take, sortBy, sortOrder);
        }

        public async Task<Project> Create(Project project)
        {
            await _uow.Projects.AddAsync(project);
            await _uow.CommitAsync();

            return project;
        }

        public async Task<Project> Update(Project project)
        {
            _uow.Projects.Update(project);
            await _uow.CommitAsync();

            return project;
        }

        public async Task Delete(int id)
        {
            await _uow.Projects.RemoveAsync(id);
            await _uow.CommitAsync();
        }
    }
}