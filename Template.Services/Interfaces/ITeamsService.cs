using Template.Data.Models;

namespace Template.Services.Interfaces
{
    public interface ITeamsService
    {
        Task<Team> Get(int id);
        Task<Tuple<IEnumerable<Team>, int>> List(int skip, int take, string sortBy, string sortOrder);
        Task<Tuple<IEnumerable<Team>, int>> List();
        Task<Team> Create(Team team);
        Task<Team> Update(Team team);
        Task Delete(int id);
    }
}