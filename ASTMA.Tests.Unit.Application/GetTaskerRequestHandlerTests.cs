using ASTMA.Application.Common.Interfaces;
using ASTMA.Application.Common.Models;
using ASTMA.Application.Taskers.Queries.GetById;
using ASTMA.Domain.Entities;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;
using FluentAssertions;
using System;

namespace ASTMA.Tests.Unit.Application
{
    public class GetTaskerRequestHandlerTests
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
            expectedTasker.Should().BeEquivalentTo(actual);
            repository.Verify(r => r.GetAsync(taskId), Times.Once);
            mapper.Verify(m => m.Map<Tasker>(taskerDto), Times.Once);
        }

        [Test]
        public async Task Handle_InvalidRequest_ThrowsArgumentNullException()
        {
            // Arrange
            var handler = new GetTaskerRequestHandler(repository.Object, mapper.Object);
            GetTaskerRequest request = null;

            // Act
            Func<Task> action = async () => await handler.Handle(request, CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>()
                        .WithMessage("Value cannot be null.");
        }

        [Test]
        public async Task Handle_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            var handler = new GetTaskerRequestHandler(repository.Object, mapper.Object);
            var request = new GetTaskerRequest { Id = 0 };

            // Act
            Func<Task> action = async () => await handler.Handle(request, CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<ArgumentException>()
                        .WithParameterName(nameof(request.Id))
                        .WithMessage("Id greater than 0 is required. (Parameter 'Id')");
        }

        //TODO Add more exceptions when the repo gets tied in.
    }
}