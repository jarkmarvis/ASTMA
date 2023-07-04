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

namespace ASTMA.Tests.Unit.Application;

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
        var taskId = "taskerId";
        var title = "Sample Title";
        var description = "Sample Description";

        var handler = new GetTaskerRequestHandler(repository.Object, mapper.Object);
        var request = new GetTaskerRequest { Id = taskId };

        var tasker = new Tasker { Title = title, Description = description };
        tasker.SetId(taskId);

        var expectedTaskerDto = new TaskerDto
        {
            Id = taskId,
            Title = title,
            Description = description
        };

        repository.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync(tasker);
        mapper.Setup(m => m.Map<TaskerDto>(It.IsAny<Tasker>())).Returns(expectedTaskerDto);

        // Act
        var actual = await handler.Handle(request, CancellationToken.None);

        // Assert
        expectedTaskerDto.Should().BeEquivalentTo(actual);
        repository.Verify(r => r.GetAsync(taskId), Times.Once);
        mapper.Verify(m => m.Map<TaskerDto>(tasker), Times.Once);
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
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public async Task Handle_InvalidId_ThrowsArgumentException(string taskerId)
    {
        // Arrange
        var handler = new GetTaskerRequestHandler(repository.Object, mapper.Object);
        var request = new GetTaskerRequest { Id = taskerId };

        // Act
        Func<Task> action = async () => await handler.Handle(request, CancellationToken.None);

        // Assert
        await action.Should().ThrowAsync<ArgumentException>()
                    .WithParameterName(nameof(request.Id))
                    .WithMessage("Id is required. (Parameter 'Id')");
    }

    //TODO Add more exceptions when the repo gets tied in.
}