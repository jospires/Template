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
    public class ProjectsServiceUT
    {
        private ProjectsService _service;
        private Mock<ITemplateUnitOfWork> _uow;

        [SetUp]
        public void SetUp()
        {
            _uow = new Mock<ITemplateUnitOfWork>();

            _service = new ProjectsService(_uow.Object);
        }

        [Test]
        [TestCaseSource(typeof(ProjectsServiceUTCases), nameof(ProjectsServiceUTCases.Get))]
        public async Task Get(int id, IEnumerable<Project> dataSet, Project expected)
        {
            //arrange
            _uow.Setup(s => s.Projects.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int filter) =>
                {
                    return dataSet.Single(w => w.ID == filter);
                });

            //act
            var response = await _service.Get(id);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Project), response);

            response.Should().BeEquivalentTo(expected, opt => opt.Excluding(e => e.StartDate).Excluding(e => e.ExpectedEndDate).Excluding(e => e.EndDate));
        }

        [Test]
        [TestCaseSource(typeof(ProjectsServiceUTCases), nameof(ProjectsServiceUTCases.List))]
        public async Task List(int skip, int take, string sortBy, string sortOrder,
            IEnumerable<Project> dataSet,
            Tuple<IEnumerable<Project>, int> expected)
        {
            //arrange
            _uow.Setup(s => s.Projects.GetAsync(
                It.IsAny<Expression<Func<Project, bool>>>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                ))
                .ReturnsAsync((Expression<Func<Project, bool>> expression,
                    string includes, int skip, int take, string sortBy, string sortOrder) =>
                {
                    var filteredData = dataSet.Skip(skip).Take(take).ToList();

                    return new Tuple<IEnumerable<Project>, int>(
                        filteredData, filteredData.Count);
                });

            //act
            var response = await _service.List(skip, take, sortBy, sortOrder);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Tuple<IEnumerable<Project>, int>), response);

            response.Item1.Should().BeEquivalentTo(expected.Item1, opt => opt.Excluding(e => e.StartDate).Excluding(e => e.ExpectedEndDate).Excluding(e => e.EndDate));
            response.Item2.Should().Be(expected.Item2);
        }

        [Test]
        [TestCaseSource(typeof(ProjectsServiceUTCases),
            nameof(ProjectsServiceUTCases.Create))]
        public async Task Create(Project Project, IEnumerable<Project> dataSet)
        {
            //arrange
            _uow.Setup(s => s.Projects.AddAsync(It.IsAny<Project>()))
                .Returns(Task.CompletedTask);

            //act
            var response = await _service.Create(Project);

            //assert
            _uow.Verify(v => v.Projects.AddAsync(It.IsAny<Project>()), Times.Once);
            _uow.Verify(v => v.CommitAsync(), Times.Once);

            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Project), response);
        }

        [Test]
        [TestCaseSource(typeof(ProjectsServiceUTCases),
            nameof(ProjectsServiceUTCases.Update))]
        public async Task Update(Project Project, Project[] dataSet)
        {
            //arrange
            _uow.Setup(s => s.Projects.Update(It.IsAny<Project>()))
                .Verifiable();

            //act
            var response = await _service.Update(Project);

            //assert
            _uow.Verify(v => v.Projects.Update(It.IsAny<Project>()), Times.Once);
            _uow.Verify(v => v.CommitAsync(), Times.Once);

            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Project), response);
        }
    }
}
