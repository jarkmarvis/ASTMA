﻿using ASTMA.Application.Common.Interfaces;
using ASTMA.Infrastructure.Documents;
using MongoDB.Driver;

namespace ASTMA.Infrastructure.Migrations;

public class DatabaseSetup
{
    private readonly IApplicationDbContext<TaskerDocument> _context;

    public DatabaseSetup(IApplicationDbContext<TaskerDocument> context)
    {
        _context = context;
    }

    public void InitializeDatabase()
    {
        CreateIndexes();
        SeedData();
        //Perform Schema steps
    }

    private void CreateIndexes()
    {
        var indexKeys = Builders<TaskerDocument>.IndexKeys.Ascending(t => t.Id);
        var indexOptions = new CreateIndexOptions { Unique = true };
        _context.Collection.Indexes.CreateOne(new CreateIndexModel<TaskerDocument>(indexKeys, indexOptions));
    }

    private void SeedData()
    {
        var tasker = new TaskerDocument
        {
            Id = "taskerId",
            Title = "Sample Task",
            Description = "A Sample task",
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow
        };

        _context.Collection.InsertOne(tasker);

        //TODO: Seed other data Users, Projects etc
    }
}

