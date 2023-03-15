using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Template.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<Tuple<IEnumerable<TEntity>, int>> GetAsync(Expression<Func<TEntity, bool>> filter, string includeProperties = null, int skip = 0, int take = 20, string sortBy = "Id", string sortOrder = "desc");
        
        Task<Tuple<IEnumerable<TEntity>, int>> GetAllAsync();

        Task<TEntity> GetByIdAsync(object id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        Task RemoveAsync(object id);
    }
}
