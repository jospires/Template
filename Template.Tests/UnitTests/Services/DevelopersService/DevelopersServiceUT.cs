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
    public class DevelopersServiceUT
    {
        private DevelopersService _service;
        private Mock<ITemplateUnitOfWork> _uow;

        [SetUp]
        public void SetUp()
        {
            _uow = new Mock<ITemplateUnitOfWork>();

            _service = new DevelopersService(_uow.Object);
        }

        [Test]
        [TestCaseSource(typeof(DevelopersServiceUTCases), nameof(DevelopersServiceUTCases.Get))]
        public async Task Get(int id, IEnumerable<Developer> dataSet, Developer expected)
        {
            //arrange
            _uow.Setup(s => s.Developers.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int filter) =>
                {
                    return dataSet.Single(w => w.ID == filter);
                });

            //act
            var response = await _service.Get(id);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Developer), response);

            response.Should().BeEquivalentTo(expected, opt => opt.Excluding(e => e.DateOfBirth));
        }

        [Test]
        [TestCaseSource(typeof(DevelopersServiceUTCases), nameof(DevelopersServiceUTCases.List))]
        public async Task List(int skip, int take, string sortBy, string sortOrder,
            IEnumerable<Developer> dataSet,
            Tuple<IEnumerable<Developer>, int> expected)
        {
            //arrange
            _uow.Setup(s => s.Developers.GetAsync(
                It.IsAny<Expression<Func<Developer, bool>>>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                ))
                .ReturnsAsync((Expression<Func<Developer, bool>> expression,
                    string includes, int skip, int take, string sortBy, string sortOrder) =>
                {
                    var filteredData = dataSet.Skip(skip).Take(take).ToList();

                    return new Tuple<IEnumerable<Developer>, int>(
                        filteredData, filteredData.Count);
                });

            //act
            var response = await _service.List(skip, take, sortBy, sortOrder);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Tuple<IEnumerable<Developer>, int>), response);

            response.Item1.Should().BeEquivalentTo(expected.Item1, opt => opt.Excluding(e => e.DateOfBirth));
            response.Item2.Should().Be(expected.Item2);
        }

        [Test]
        [TestCaseSource(typeof(DevelopersServiceUTCases),
            nameof(DevelopersServiceUTCases.Create))]
        public async Task Create(Developer Developer, IEnumerable<Developer> dataSet)
        {
            //arrange
            _uow.Setup(s => s.Developers.AddAsync(It.IsAny<Developer>()))
                .Returns(Task.CompletedTask);

            //act
            var response = await _service.Create(Developer);

            //assert
            _uow.Verify(v => v.Developers.AddAsync(It.IsAny<Developer>()), Times.Once);
            _uow.Verify(v => v.CommitAsync(), Times.Once);

            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Developer), response);
        }

        [Test]
        [TestCaseSource(typeof(DevelopersServiceUTCases),
            nameof(DevelopersServiceUTCases.Update))]
        public async Task Update(Developer Developer, Developer[] dataSet)
        {
            //arrange
            _uow.Setup(s => s.Developers.Update(It.IsAny<Developer>()))
                .Verifiable();

            //act
            var response = await _service.Update(Developer);

            //assert
            _uow.Verify(v => v.Developers.Update(It.IsAny<Developer>()), Times.Once);
            _uow.Verify(v => v.CommitAsync(), Times.Once);

            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(Developer), response);
        }
    }
}
