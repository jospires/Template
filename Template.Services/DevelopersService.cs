using Template.Data.Models;
using Template.Data.UnitsOfWork;
using Template.Services.Interfaces;

namespace Template.Services
{
    public class DevelopersService : IDevelopersService
    {
        private readonly ITemplateUnitOfWork _uow;


        public DevelopersService(ITemplateUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Developer> Get(int id)
        {
            return await _uow.Developers.GetByIdAsync(id);
        }

        public async Task<Tuple<IEnumerable<Developer>, int>> List(int skip, int take, string sortBy, string sortOrder)
        {
            return await _uow.Developers.GetAsync(null, "Team", skip, take, sortBy, sortOrder);
        }

        public async Task<Developer> Create(Developer developer)
        {
            await _uow.Developers.AddAsync(developer);
            await _uow.CommitAsync();

            return developer;
        }

        public async Task<Developer> Update(Developer developer)
        {
            _uow.Developers.Update(developer);
            await _uow.CommitAsync();

            return developer;
        }
        
        public async Task Delete(int id)
        {
            await _uow.Developers.RemoveAsync(id);
            await _uow.CommitAsync();
        }
    }
}