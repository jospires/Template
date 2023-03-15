using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;
using Template.Data.Models;
using Template.Data.UnitsOfWork;
using Template.Services;

namespace Template.Tests.UnitTests.Services
{
    [TestFixture]
    public class TeamsServiceUT
    {
        private TeamsService _service;
        private Mock<ITemplateUnitOfWork> _uow;

        [SetUp]
        public void SetUp()
        {
            _uow = new Mock<ITemplateUnitOfWork>();

            _service = new TeamsService(_uow.Object);
        }

        [Test]
        [TestCaseSource(typeof(TeamsServiceUTCases), nameof(TeamsServiceUTCases.Get))]
        public async Task Get(int id, IEnumerable<Team> dataSet, Team expected)
        {
            //arrange
            _uow.Setup(s => s.Teams.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int filter) =>
                {
                    return dataSet.Single(w => w.ID == filter);
                });

            //act
            var response = await _service.Get(id);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Team), response);

            response.Should().BeEquivalentTo(expected);
        }

        [Test]
        [TestCaseSource(typeof(TeamsServiceUTCases), nameof(TeamsServiceUTCases.List))]
        public async Task List(int skip, int take, string sortBy, string sortOrder,
            IEnumerable<Team> dataSet,
            Tuple<IEnumerable<Team>, int> expected)
        {
            //arrange
            _uow.Setup(s => s.Teams.GetAsync(
                It.IsAny<Expression<Func<Team, bool>>>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                ))
                .ReturnsAsync((Expression<Func<Team, bool>> expression,
                    string includes, int skip, int take, string sortBy, string sortOrder) =>
                {
                    var filteredData = dataSet.Skip(skip).Take(take).ToList();

                    return new Tuple<IEnumerable<Team>, int>(
                        filteredData, filteredData.Count);
                });

            //act
            var response = await _service.List(skip, take, sortBy, sortOrder);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Tuple<IEnumerable<Team>, int>), response);

            response.Item1.Should().BeEquivalentTo(expected.Item1);
            response.Item2.Should().Be(expected.Item2);
        }

        [Test]
        [TestCaseSource(typeof(TeamsServiceUTCases),
            nameof(TeamsServiceUTCases.Create))]
        public async Task Create(Team team, IEnumerable<Team> dataSet)
        {
            //arrange
            _uow.Setup(s => s.Teams.AddAsync(It.IsAny<Team>()))
                .Returns(Task.CompletedTask);

            //act
            var response = await _service.Create(team);

            //assert
            _uow.Verify(v => v.Teams.AddAsync(It.IsAny<Team>()), Times.Once);
            _uow.Verify(v => v.CommitAsync(), Times.Once);

            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Team), response);
        }

        [Test]
        [TestCaseSource(typeof(TeamsServiceUTCases),
            nameof(TeamsServiceUTCases.Update))]
        public async Task Update(Team team, Team[] dataSet)
        {
            //arrange
            _uow.Setup(s => s.Teams.Update(It.IsAny<Team>()))
                .Verifiable();

            //act
            var response = await _service.Update(team);

            //assert
            _uow.Verify(v => v.Teams.Update(It.IsAny<Team>()), Times.Once);
            _uow.Verify(v => v.CommitAsync(), Times.Once);

            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Team), response);
        }
    }
}
