using ASTMA.Application.Common.Interfaces;
using ASTMA.Infrastructure.Documents;
using ASTMA.Infrastructure.Repositories;
using AutoMapper;
using MongoDB.Driver;
using Moq;
using FluentAssertions;
using ASTMA.Infrastructure.Persistence;
using System.Collections;

namespace ASTMA.Tests.Unit.Infrastructure
{
    [TestFixture]
    public class Tests
    {
        private Mock<IMongoCollection<TaskerDocument>> _mockTaskerCollection;
        private Mock<IMongoDbContext<TaskerDocument>> _mockMongoDbContext;
        private Mock<IMapper> _mapper;
        private TaskerRepository _taskerRepository;

        //private Mock<TaskerRepository> _taskerRepository;

        [SetUp]
        public void SetUp()
        {
            _mockTaskerCollection = new Mock<IMongoCollection<TaskerDocument>>();
            _mockMongoDbContext = new Mock<IMongoDbContext<TaskerDocument>>();
            _mapper = new Mock<IMapper>();

            _mockMongoDbContext.Setup(db => db.Database.GetCollection<TaskerDocument>("taskers", null))
                .Returns(_mockTaskerCollection.Object);

            _taskerRepository = new TaskerRepository(_mockMongoDbContext.Object, _mapper.Object);
        }

        [Test]
        public async Task GetById_WhenExists_ReturnsTasker()
        {
            // Arrange
            var expected = new TaskerDocument { Id = 1, Title = "Sample Task Title" };
            _mockTaskerCollection.Setup(collection => collection.Find(It.IsAny<FilterDefinition<TaskerDocument>>(), null))
                .Returns(MockCursor(expected));

            // Act
            var result = await _taskerRepository.GetAsync(expected.Id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(expected.Id);
            result.Description.Should().Be(expected.Description);
        }

        [Test]
        public void GetById_WhenUserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var _taskerRepository = new TaskerRepository(_mockMongoDbContext.Object, _mapper.Object);
            _mockMongoDbContext.Setup(context => context.Collection.Find(It.IsAny<FilterDefinition<TaskerDocument>>(), default))
                .Returns(MockCursor(new TaskerDocument()));

            // Act
            var result = _taskerRepository.GetAsync(0);

            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// Creates a mock object of the IFindFluent<TaskerDocument, TaskerDocument>
        /// </summary>
        /// <param name="tasker">TaskerDocument</param>
        /// <returns>Mock IFindFluent<TaskerDocument, TaskerDocument> Object</returns>
        private IFindFluent<TaskerDocument, TaskerDocument> MockCursor(TaskerDocument tasker)
        {
            var mockCursor = new Mock<IFindFluent<TaskerDocument, TaskerDocument>>();
            mockCursor.Setup(cursor => cursor.FirstOrDefault(It.IsAny<CancellationToken>())).Returns(tasker);
            return mockCursor.Object;
        }
    }
}