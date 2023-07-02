using ASTMA.Application.Common.Interfaces;
using ASTMA.Application.Common.Models;
using ASTMA.Application.Taskers.Queries.GetById;
using ASTMA.Domain.Entities;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;

namespace ASTMA.Tests.Unit.Application
{
    public class Tests
    {
        private Mock<ITaskerRepository> repository;
        private Mock<IMapper> mapper;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<ITaskerRepository>();
            mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task Handle_ValidRequest_CreatesTasker()
        {
            // Arrange
            int taskId = 1;
            var title = "Sample Title";
            var description = "Sample Description";

            var handler = new GetTaskerRequestHandler(repository.Object, mapper.Object);
            var request = new GetTaskerRequest { Id = taskId };

            var taskerDto = new TaskerDto 
            { 
                Id = taskId, 
                Title = title, 
                Description = description 
            };
            var expectedTasker = new Tasker
            {
                Title = title,
                Description = description
            };
            expectedTasker.SetId(taskId);

            repository.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync(taskerDto);
            mapper.Setup(m => m.Map<Tasker>(It.IsAny<TaskerDto>())).Returns(expectedTasker);

            // Act
            var actual = await handler.Handle(request, CancellationToken.None);

            // Assert
            AssertExtensions.Equivalent(expectedTasker, actual);
            repository.Verify(r => r.GetAsync(taskId), Times.Once);
            mapper.Verify(m => m.Map<Tasker>(taskerDto), Times.Once);
        }
    }
}