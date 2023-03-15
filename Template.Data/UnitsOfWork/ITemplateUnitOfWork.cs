using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Models;
using Template.Data.Repositories;

namespace Template.Data.UnitsOfWork
{
    public interface ITemplateUnitOfWork : IUnitOfWork
    {
        IRepository<Team> Teams { get; }
        IRepository<Project> Projects { get; }
        IRepository<Developer> Developers { get; }
    }
}
