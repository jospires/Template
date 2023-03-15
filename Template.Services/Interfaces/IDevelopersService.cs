
using Template.Data.Models;

namespace Template.Services.Interfaces
{
    public interface IDevelopersService
    {
        Task<Developer> Get(int id);
        Task<Tuple<IEnumerable<Developer>, int>> List(int skip, int take, string sortBy, string sortOrder);
        Task<Developer> Create(Developer developer);
        Task<Developer> Update(Developer developer);
        Task Delete(int id);
    }
}