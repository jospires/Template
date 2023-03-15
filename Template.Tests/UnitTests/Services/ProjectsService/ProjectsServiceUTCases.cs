using Template.Data.Models;

namespace Template.Tests.UnitTests.Services
{
    public class ProjectsServiceUTCases
    {
        public DateTime date = DateTime.UtcNow;

        public static readonly object[] Get = {
            new object[]
            {
                1,
                ProjectsDbSet(),
                new Project
                {
                    ID = 1,
                    TeamID = 1,
                    Name = "DevProject #1",
                    Description = "Description 1",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                },
            },
            new object[]
            {
                3,
                ProjectsDbSet(),
                new Project
                {
                    ID = 3,
                    TeamID = 1,
                    Name = "DevProject #3",
                    Description = "Description 3",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
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
                ProjectsDbSet(),
                new Tuple<IEnumerable<Project>, int>(ListProjectsDbSet(), 2)
            },
            new object[]
            {
                0,
                1,
                "id",
                "asc",
                ProjectsDbSet(),
                new Tuple<IEnumerable<Project>, int>(new Project[] {
                new Project
                {
                    ID = 1,
                    TeamID = 1,
                    Name = "DevProject #1",
                    Description = "Description 1",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                } }, 1)
            }
        };

        public static readonly object[] Create = {
            new object[]
            {
                new Project {
                    TeamID = 1,
                    Name = "DevProject #4",
                    Description = "Description 4",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                },
                ProjectsDbSet()
            },
        };

        public static readonly object[] Update = {
            new object[]
            {
                new Project {
                    ID = 1,
                    TeamID = 1,
                    Name = "DevProject #1 Updated",
                    Description = "Description 1",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                },
                ProjectsDbSet()
            },
        };

        private static Project[] ProjectsDbSet()
        {
            return new Project[]
            {
                new Project
                {
                    ID = 1,
                    TeamID = 1,
                    Name = "DevProject #1",
                    Description = "Description 1",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                },
                new Project
                {
                    ID = 2,
                    TeamID = 1,
                    Name = "DevProject #2",
                    Description = "Description 2",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                },
                new Project
                {
                    ID = 3,
                    TeamID = 1,
                    Name = "DevProject #3",
                    Description = "Description 3",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                }
            };
        }

        private static Project[] ListProjectsDbSet()
        {
            return new Project[]
            {
                new Project
                {
                    ID = 1,
                    TeamID = 1,
                    Name = "DevProject #1",
                    Description = "Description 1",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                },
                new Project
                {
                    ID = 2,
                    TeamID = 1,
                    Name = "DevProject #2",
                    Description = "Description 2",
                    StartDate= DateTime.Now,
                    ExpectedEndDate= DateTime.Now,
                    EndDate= DateTime.Now,
                }
            };
        }
    }
}
