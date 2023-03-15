using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Template.Data.Models;

namespace Template.Tests.UnitTests.Data.Repository
{
    public class RepositoryUTCases
    {

        public static readonly object[] GetByIdAsync =
        {
            new object[]
            {
                1,
                TeamsDbSet(),
                new Team
                {
                    ID = 1,
                    Name = "DevTeam #1",
                    Description = "Description 1",
                }
            },
            new object[]
            {
                3,
                TeamsDbSet(),
                new Team
                {
                    ID = 3,
                    Name = "DevTeam #3",
                    Description = "Description 3",
                }
            },
        };

        public static readonly object[] GetAsync =
        {
            new object[]
            {
                0,
                2,
                "ID",
                "desc",
                TeamsDbSet(),
                new Tuple<IEnumerable<Team>, int>(
                    new Team[]
                    {
                        new Team
                        {
                            ID = 3,
                            Name = "DevTeam #3",
                            Description = "Description 3",
                        },
                        new Team
                        {
                            ID = 2,
                            Name = "DevTeam #2",
                            Description = "Description 2",
                        },
                    },3)
            },
        };

        public static readonly object[] Add =
        {
            new object[]
            {
                new Team
                {
                    Name = "DevTeam #4",
                    Description = "Description 4",
                },
            }
        };

        public static readonly object[] Update =
        {
            new object[]
            {
                new Team
                {
                    ID = 3,
                    Name = "DevTeam #3",
                    Description = "Description 3",
                },
                "New Description"
            },
        };

        public static readonly object[] Remove =
        {
            new object[]
            {
                TeamsDbSet(),
                new Team[]
                {
                    new Team
                    {
                        ID = 2,
                        Name = "DevTeam #2",
                        Description = "Description 2",
                    },
                    new Team
                    {
                        ID = 3,
                        Name = "DevTeam #3",
                        Description = "Description 3",
                    }
                }
            }
        };

        private static Team[] TeamsDbSet()
        {
            return new Team[]
            {
                new Team
                {
                    ID = 1,
                    Name = "DevTeam #1",
                    Description = "Description 1",
                },
                new Team
                {
                    ID = 2,
                    Name = "DevTeam #2",
                    Description = "Description 2",
                },
                new Team
                {
                    ID = 3,
                    Name = "DevTeam #3",
                    Description = "Description 3",
                }
            };
        }

    }
}
