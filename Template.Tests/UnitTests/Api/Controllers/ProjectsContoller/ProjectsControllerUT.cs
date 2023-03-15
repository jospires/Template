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
    public class ProjectsControllerUT
    {
        private ProjectsController _controller;
        private Mock<IProjectsService> _service;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<IProjectsService>();

            _controller = new ProjectsController(_service.Object);
        }

        [Test]
        [TestCaseSource(typeof(ProjectsControllerUTCases),
            nameof(ProjectsControllerUTCases.Get))]
        public async Task Get(int id)
        {
            //arrange
            _service.Setup(s => s.Get(It.IsAny<int>())).Returns(
                Task.FromResult<Project>(new Project()));

            //act
            var response = await _controller.Get(id);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkObjectResult), response);
        }

        [Test]
        [TestCaseSource(typeof(ProjectsControllerUTCases),
            nameof(ProjectsControllerUTCases.List))]
        public async Task List(int skip, int take, string sortBy, string sortOrder)
        {
            //arrange
            _service.Setup(s => s.List(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).Returns(
                Task.FromResult(new Tuple<IEnumerable<Project>, int>(
                         new[] { new Project() }, 1)));

            //act
            var response = await _controller.List(skip, take, sortBy, sortOrder);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkObjectResult), response);
        }

        [Test]
        [TestCaseSource(typeof(ProjectsControllerUTCases),
            nameof(ProjectsControllerUTCases.Create))]
        public async Task Create(ProjectVM project)
        {
            //arrange
            _service.Setup(s => s.Create(It.IsAny<Project>())).Returns(
                Task.FromResult(new Project()));

            //act
            var response = await _controller.Create(project);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkResult), response);
        }

        [Test]
        [TestCaseSource(typeof(ProjectsControllerUTCases),
           nameof(ProjectsControllerUTCases.Update))]
        public async Task Update(ProjectVM project)
        {
            //arrange
            _service.Setup(s => s.Update(It.IsAny<Project>())).Returns(
                Task.FromResult<Project>(new Project()));

            //act
            var response = await _controller.Update(project);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkResult), response);
        }

    }
}
