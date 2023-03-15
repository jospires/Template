using Template.Data.Models;

namespace Template.Tests.UnitTests.Services
{
    public class TeamsServiceUTCases
    {
        public static readonly object[] Get = {
            new object[]
            {
                1,
                TeamsDbSet(),
                new Team
                {
                    ID = 1,
                    Name = "DevTeam #1",
                    Description = "Description 1",
                },
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
                },
            },
        };

        public static readonly object[] List = {
            new object[]
            {
                0,
                2,
                "id",
                "asc",
                TeamsDbSet(),
                new Tuple<IEnumerable<Team>, int>(ListTeamsDbSet(), 2)
            },
            new object[]
            {
                0,
                1,
                "id",
                "asc",
                TeamsDbSet(),
                new Tuple<IEnumerable<Team>, int>(new Team[] {
                new Team
                {
                    ID = 1,
                    Name = "DevTeam #1",
                    Description = "Description 1",
                } }, 1)
            }
        };

        public static readonly object[] Create = {
            new object[]
            {
                new Team {
                    Name = "DevTeam #4",
                    Description = "Description 4",
                },
                TeamsDbSet()
            },
        };

        public static readonly object[] Update = {
            new object[]
            {
                new Team {
                    ID = 1,
                    Name = "DevTeam #1 Updated",
                    Description = "Description 1",
                },
                TeamsDbSet()
            },
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

        private static Team[] ListTeamsDbSet()
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
                }
            };
        }
    }
}
