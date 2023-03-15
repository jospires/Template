using Template.Data.Models;
using Template.Data.UnitsOfWork;
using Template.Services.Interfaces;

namespace Template.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ITemplateUnitOfWork _uow;

        public TeamsService(ITemplateUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Team> Get(int id)
        {
            return await _uow.Teams.GetByIdAsync(id);
        }

        public async Task<Tuple<IEnumerable<Team>, int>> List(int skip, int take, string sortBy, string sortOrder)
        {
            return await _uow.Teams.GetAsync(null, "Developers,Projects", skip, take, sortBy, sortOrder);
        }

        public async Task<Tuple<IEnumerable<Team>, int>> List()
        {
            return await _uow.Teams.GetAllAsync();
        }

        public async Task<Team> Create(Team team)
        {
            await _uow.Teams.AddAsync(team);
            await _uow.CommitAsync();

            return team;
        }

        public async Task<Team> Update(Team team)
        {
            _uow.Teams.Update(team);
            await _uow.CommitAsync();

            return team;
        }

        public async Task Delete(int id)
        {
            await _uow.Teams.RemoveAsync(id);
            await _uow.CommitAsync();
        }
    }
}