using Template.Api.ViewModels;
using Template.Data.Models;

namespace Template.Tests.UnitTests.Api.Controllers
{
    public class ProjectsControllerUTCases
    {
        public static readonly object[] Get = {
            new object[]
            {
                1,
            }
        };

        public static readonly object[] List = {
            new object[]
            {
                0,
                2,
                "id",
                "asc",
            }
        };

        public static readonly object[] Create = {
            new object[]
            {
                new ProjectVM()
                {
                    TeamID = 1,
                    Name = "DevProject #3",
                    Description = "Description 3",
                    StartDate = DateTime.Now,
                    ExpectedEndDate = DateTime.Now,
                    EndDate = DateTime.Now,
                },
            }
        };

        public static readonly object[] Update = {
            new object[]
            {
                new ProjectVM()
                {
                    TeamID = 1,
                    Name = "DevProject #1",
                    Description = "Description 1 UPDATED",
                    StartDate = DateTime.Now,
                    ExpectedEndDate = DateTime.Now,
                    EndDate = DateTime.Now,
                },
            }
        };

        public static readonly object[] Delete = {
            new object[]
            {
                1,
            }
        };

    }
}
