using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Template.Api.Controllers;
using Template.Api.ViewModels;
using Template.Data.Models;
using Template.Services.Interfaces;

namespace Template.Tests.UnitTests.Api.Controllers
{
    [TestFixture]
    public class TeamsControllerUT
    {
        private TeamsController _controller;
        private Mock<ITeamsService> _service;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<ITeamsService>();

            _controller = new TeamsController(_service.Object);
        }

        [Test]
        [TestCaseSource(typeof(TeamsControllerUTCases),
            nameof(TeamsControllerUTCases.Get))]
        public async Task Get(int id)
        {
            //arrange
            _service.Setup(s => s.Get(It.IsAny<int>())).Returns(
                Task.FromResult<Team>(new Team()));

            //act
            var response = await _controller.Get(id);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkObjectResult), response);
        }

        [Test]
        [TestCaseSource(typeof(TeamsControllerUTCases),
            nameof(TeamsControllerUTCases.List))]
        public async Task List(int skip, int take, string sortBy, string sortOrder)
        {
            //arrange
            _service.Setup(s => s.List(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).Returns(
                Task.FromResult(new Tuple<IEnumerable<Team>, int>(
                         new[] { new Team() }, 1)));

            //act
            var response = await _controller.List(skip, take, sortBy, sortOrder);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkObjectResult), response);
        }

        [Test]
        [TestCaseSource(typeof(TeamsControllerUTCases),
            nameof(TeamsControllerUTCases.Create))]
        public async Task Create(TeamVM team)
        {
            //arrange
            _service.Setup(s => s.Create(It.IsAny<Team>())).Returns(
                Task.FromResult(new Team()));

            //act
            var response = await _controller.Create(team);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkResult), response);
        }

        [Test]
        [TestCaseSource(typeof(TeamsControllerUTCases),
           nameof(TeamsControllerUTCases.Update))]
        public async Task Update(TeamVM team)
        {
            //arrange
            _service.Setup(s => s.Update(It.IsAny<Team>())).Returns(
                Task.FromResult<Team>(new Team()));

            //act
            var response = await _controller.Update(team);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkResult), response);
        }

    }
}
