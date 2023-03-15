using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Template.Data.Models;
using Template.Data.Repositories;
using FluentAssertions;
using NUnit.Framework;
using Template.Tests.Extensions;

namespace Template.Tests.UnitTests.Data.Repository
{
    [TestFixture]
    public class RepositoryUT
    {
        private Repository<Team> _repository;
        private TemplateDbContext _dbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TemplateDbContext>()
                .UseInMemoryDatabase(databaseName: "TemplateDbContext")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            _dbContext = new TemplateDbContext(options);

            _repository = new Repository<Team>(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Test]
        [TestCaseSource(typeof(RepositoryUTCases),
            nameof(RepositoryUTCases.GetByIdAsync))]
        public async Task GetByIdAsync(int id, Team[] dataSet, Team expected)
        {
            //arrange
            await _dbContext.Seed<Team>(dataSet);

            //act
            var response = await _repository.GetByIdAsync(id);

            //assert
            response.Should().BeEquivalentTo(expected);
        }

        [Test]
        [TestCaseSource(typeof(RepositoryUTCases),
            nameof(RepositoryUTCases.GetAsync))]
        public async Task GetAsync(int skip, int take, string sortBy, string sortOrder, Team[] dataSet, Tuple<IEnumerable<Team>, int> expected)
        {
            //arrange
            await _dbContext.Seed<Team>(dataSet);

            //act
            var response = await _repository.GetAsync(w => true, null, skip, take, sortBy, sortOrder);

            //assert
            response.Should().BeEquivalentTo(expected);
        }

        [Test]
        [TestCaseSource(typeof(RepositoryUTCases),
            nameof(RepositoryUTCases.Add))]
        public async Task Add(Team newObject)
        {
            //arrange

            //act
            await _repository.AddAsync(newObject);
            _dbContext.SaveChanges();

            var expected = await _dbContext.Teams.SingleAsync(w => w.ID == newObject.ID);

            //assert
            expected.Should().BeEquivalentTo(newObject);
        }

        [Test]
        [TestCaseSource(typeof(RepositoryUTCases),
            nameof(RepositoryUTCases.Update))]
        public async Task Update(Team newObject, string newValue)
        {
            //arrange
            await _dbContext.Seed<Team>(newObject);
            newObject.Description = newValue;

            //act
            _repository.Update(newObject);
            _dbContext.SaveChanges();

            var expected = await _dbContext.Teams.SingleAsync(w => w.ID == newObject.ID);

            //assert
            expected.Should().BeEquivalentTo(newObject);
        }

        [Test]
        [TestCaseSource(typeof(RepositoryUTCases),
            nameof(RepositoryUTCases.Remove))]
        public async Task Remove(Team[] dataSet, Team[] expected)
        {
            //arrange
            await _dbContext.Seed<Team>(dataSet);

            //act
            await _repository.RemoveAsync(dataSet[0].ID);
            _dbContext.SaveChanges();

            var all = await _dbContext.Teams.ToListAsync();

            //assert
            all.Should().BeEquivalentTo(expected);
        }

    }
}
