using Template.Api.ViewModels;
using Template.Data.Models;

namespace Template.Tests.UnitTests.Api.Controllers
{
    public class TeamsControllerUTCases
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
                new TeamVM()
                {
                    Name = "DevTeam #3",
                    Description = "Description 3"
                },
            }
        };

        public static readonly object[] Update = {
            new object[]
            {
                new TeamVM()
                {
                    ID = 1,
                    Name = "DevTeam #1",
                    Description = "Description 1 UPDATE"
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
