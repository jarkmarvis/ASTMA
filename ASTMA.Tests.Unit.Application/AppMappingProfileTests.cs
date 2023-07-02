using ASTMA.Application.Common.Mappings;
using ASTMA.Application.Common.Models;
using ASTMA.Application.Taskers.Queries.GetByFilter;
using ASTMA.Domain.Entities;
using AutoMapper;
using NUnit.Framework;
using System;
using System.Runtime.Serialization;

namespace ASTMA.Tests.Unit.Application;

public class AppMappingProfileTests
{
    private readonly IConfigurationProvider _configuration;
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
        var _configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AppMappingProfile>();
        });

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AppMappingProfile>());
        config.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Tasker), typeof(TaskerDto))]
    [TestCase(typeof(TaskerDto), typeof(Tasker))]
    [TestCase(typeof(GetTaskerArgs), typeof(GetTaskersParams))]
    [TestCase(typeof(GetTaskersParams), typeof(GetTaskerArgs))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        //Arrange
        var instance = GetInstanceOf(source);

        //Act
        var result = _mapper.Map(instance, source, destination);

        //Assert
        Assert.AreEqual(destination.FullName, result.GetType().FullName);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        // TODO: Find an alternative to the obsolete `FormatterServices.GetUninitializedObject` method.
        // Type or member is obsolete
        return FormatterServices.GetUninitializedObject(type);
    }
}
