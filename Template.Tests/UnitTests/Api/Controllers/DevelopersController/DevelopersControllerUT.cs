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
    public class DevelopersControllerUT
    {
        private DevelopersController _controller;
        private Mock<IDevelopersService> _service;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<IDevelopersService>();

            _controller = new DevelopersController(_service.Object);
        }

        [Test]
        [TestCaseSource(typeof(DevelopersControllerUTCases),
            nameof(DevelopersControllerUTCases.Get))]
        public async Task Get(int id)
        {
            //arrange
            _service.Setup(s => s.Get(It.IsAny<int>())).Returns(
                Task.FromResult<Developer>(new Developer()));

            //act
            var response = await _controller.Get(id);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkObjectResult), response);
        }

        [Test]
        [TestCaseSource(typeof(DevelopersControllerUTCases),
            nameof(DevelopersControllerUTCases.List))]
        public async Task List(int skip, int take, string sortBy, string sortOrder)
        {
            //arrange
            _service.Setup(s => s.List(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).Returns(
                Task.FromResult(new Tuple<IEnumerable<Developer>, int>(
                         new[] { new Developer() }, 1)));

            //act
            var response = await _controller.List(skip, take, sortBy, sortOrder);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkObjectResult), response);
        }

        [Test]
        [TestCaseSource(typeof(DevelopersControllerUTCases),
            nameof(DevelopersControllerUTCases.Create))]
        public async Task Create(DeveloperVM developer)
        {
            //arrange
            _service.Setup(s => s.Create(It.IsAny<Developer>())).Returns(
                Task.FromResult(new Developer()));

            //act
            var response = await _controller.Create(developer);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkResult), response);
        }

        [Test]
        [TestCaseSource(typeof(DevelopersControllerUTCases),
           nameof(DevelopersControllerUTCases.Update))]
        public async Task Update(DeveloperVM developer)
        {
            //arrange
            _service.Setup(s => s.Update(It.IsAny<Developer>())).Returns(
                Task.FromResult(new Developer()));

            //act
            var response = await _controller.Update(developer);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(OkResult), response);
        }

    }
}
