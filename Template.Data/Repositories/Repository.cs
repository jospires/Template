using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Template.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbCcontext)
        {
            _dbContext = dbCcontext;
        }

        public async Task<Tuple<IEnumerable<TEntity>, int>> GetAsync(Expression<Func<TEntity, bool>> filter, string includeProperties = null, int skip = 0, int take = 20, string sortBy = "Id", string sortOrder = "desc")
        {
            includeProperties = includeProperties ?? string.Empty;

            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var total = query.Count();

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortOrder?.ToLower() == "desc")
                {
                    query = query.OrderByDescending(o => EF.Property<object>(o, sortBy));
                }
                else
                {
                    query = query.OrderBy(o => EF.Property<object>(o, sortBy));
                }
            }

            return new Tuple<IEnumerable<TEntity>, int>(await query.Skip((int)skip).Take((int)take).ToListAsync(), total);
        }

        public async Task<Tuple<IEnumerable<TEntity>, int>> GetAllAsync()
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            var total = query.Count();

            return new Tuple<IEnumerable<TEntity>, int>(await query.ToListAsync(), total);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task RemoveAsync(object id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

    }
}
