using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Models;
using Template.Data.Repositories;

namespace Template.Data.UnitsOfWork
{
    public class TemplateUnitOfWork : UnitOfWork, ITemplateUnitOfWork
    {
        private readonly Lazy<IRepository<Team>> LazyTeams;
        public IRepository<Team> Teams => LazyTeams.Value;

        private readonly Lazy<IRepository<Project>> LazyProjects;
        public IRepository<Project> Projects => LazyProjects.Value;

        private readonly Lazy<IRepository<Developer>> LazyDevelopers;
        public IRepository<Developer> Developers => LazyDevelopers.Value;

        public TemplateUnitOfWork(TemplateDbContext dbContext) : base(dbContext)
        {
            LazyTeams = new Lazy<IRepository<Team>>(() => new Repository<Team>(dbContext));
            LazyProjects = new Lazy<IRepository<Project>>(() => new Repository<Project>(dbContext));
            LazyDevelopers = new Lazy<IRepository<Developer>>(() => new Repository<Developer>(dbContext));
        }
    }
}
