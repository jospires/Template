using Template.Api.ViewModels;
using Template.Data.Models;

namespace Template.Tests.UnitTests.Api.Controllers
{
    public class DevelopersControllerUTCases
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
                new DeveloperVM()
                {
                    TeamID = 1,
                    FirstName = "First",
                    LastName = "Last",
                    Email = "email@mail.com",
                    DateOfBirth = DateTime.Now
                },
            }
        };

        public static readonly object[] Update = {
            new object[]
            {
                new DeveloperVM()
                {
                    TeamID = 1,
                    FirstName = "First UPDATED",
                    LastName = "Last UPDATED",
                    Email = "email@mail.com",
                    DateOfBirth = DateTime.Now
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
