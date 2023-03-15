using Template.Data.Models;

namespace Template.Tests.UnitTests.Services
{
    public class DevelopersServiceUTCases
    {
        public DateTime date = DateTime.UtcNow;

        public static readonly object[] Get = {
            new object[]
            {
                1,
                DevelopersDbSet(),
                new Developer
                {
                    ID = 1,
                    TeamID = 1,
                    FirstName = "First",
                    LastName = "Last",
                    Email = "email@mail.com",
                    DateOfBirth = DateTime.Now
                },
            },
            new object[]
            {
                3,
                DevelopersDbSet(),
                new Developer
                {
                    ID = 3,
                    TeamID = 1,
                    FirstName = "First3",
                    LastName = "Last3",
                    Email = "email3@mail.com",
                    DateOfBirth = DateTime.Now
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
                DevelopersDbSet(),
                new Tuple<IEnumerable<Developer>, int>(ListDevelopersDbSet(), 2)
            },
            new object[]
            {
                0,
                1,
                "id",
                "asc",
                DevelopersDbSet(),
                new Tuple<IEnumerable<Developer>, int>(new Developer[] {
                new Developer
                {
                    ID = 1,
                    TeamID = 1,
                    FirstName = "First",
                    LastName = "Last",
                    Email = "email@mail.com",
                    DateOfBirth = DateTime.Now
                } }, 1)
            }
        };

        public static readonly object[] Create = {
            new object[]
            {
                new Developer {
                    TeamID = 1,
                    FirstName = "First",
                    LastName = "Last",
                    Email = "email@mail.com",
                    DateOfBirth = DateTime.Now
                },
                DevelopersDbSet()
            },
        };

        public static readonly object[] Update = {
            new object[]
            {
                new Developer {
                    ID = 1,
                    TeamID = 1,
                    FirstName = "First UPDATE",
                    LastName = "Last",
                    Email = "email@mail.com",
                    DateOfBirth = DateTime.Now
                },
                DevelopersDbSet()
            },
        };

        private static Developer[] DevelopersDbSet()
        {
            return new Developer[]
            {
                new Developer
                {
                    ID = 1,
                    TeamID = 1,
                    FirstName = "First",
                    LastName = "Last",
                    Email = "email@mail.com",
                    DateOfBirth = DateTime.Now
                },
                new Developer
                {
                    ID = 2,
                    TeamID = 1,
                    FirstName = "First2",
                    LastName = "Last2",
                    Email = "email2@mail.com",
                    DateOfBirth = DateTime.Now
                },
                new Developer
                {
                    ID = 3,
                    TeamID = 1,
                    FirstName = "First3",
                    LastName = "Last3",
                    Email = "email3@mail.com",
                    DateOfBirth = DateTime.Now
                }
            };
        }

        private static Developer[] ListDevelopersDbSet()
        {
            return new Developer[]
            {
                new Developer
                {
                    ID = 1,
                    TeamID = 1,
                    FirstName = "First",
                    LastName = "Last",
                    Email = "email@mail.com",
                    DateOfBirth = DateTime.Now
                },
                new Developer
                {
                    ID = 2,
                    TeamID = 1,
                    FirstName = "First2",
                    LastName = "Last2",
                    Email = "email2@mail.com",
                    DateOfBirth = DateTime.Now
                }
            };
        }
    }
}
