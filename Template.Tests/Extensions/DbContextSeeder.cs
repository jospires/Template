using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Tests.Extensions
{
    public static class DbContextSeeder
    {
        public static async Task Seed<TEntity>(this DbContext context, TEntity[] data) where TEntity : class
        {
            await context.Set<TEntity>().AddRangeAsync(data);
            context.SaveChanges();
        }

        public static async Task Seed<TEntity>(this DbContext context, TEntity data) where TEntity : class
        {
            await context.Set<TEntity>().AddAsync(data);
            context.SaveChanges();
        }
    }
}
