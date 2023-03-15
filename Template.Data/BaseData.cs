using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Template.Data.Models;

namespace Template.Data
{
    public class BaseData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TemplateDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TemplateDbContext>>()))
            {
                // Look for any board games.
                if (context.Teams.Any())
                {
                    return;   // Data was already seeded
                }

                for (int i = 0; i < 20; i++)
                {
                    var team = new Team()
                    {
                        Name = $"DevTeam #{i}",
                        Description = $"Description {i}",
                    };
                    context.Teams.Add(team);

                    context.SaveChanges();

                    for (int j = 0; j < 6; j++)
                    {
                        context.Developers.Add(new Developer()
                        {
                            FirstName = $"First_{i}_{j}",
                            LastName = $"Last_{i}_{j}",
                            Email = $"First.Last_{i}_{j}@mail.com",
                            DateOfBirth = DateTime.UtcNow.AddYears(-30),
                            TeamID = team.ID,
                        });

                        context.SaveChanges();
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        context.Projects.Add(new Project()
                        {
                            Name = $"Project_{i}_{j}",
                            Description = $"Description{i}_{j}",
                            StartDate = DateTime.UtcNow.AddMonths(-6),
                            ExpectedEndDate = DateTime.UtcNow.AddMonths(-3),
                            EndDate = DateTime.UtcNow,
                            TeamID = team.ID,
                        });

                        context.SaveChanges();
                    }
                }
                
            }
        }
    }
}
