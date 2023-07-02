using ASTMA.Application.Common.Interfaces;
using ASTMA.Infrastructure.Documents;
using MongoDB.Bson;
using MongoDB.Driver;


namespace ASTMA.Infrastructure.Persistence.Migration;


public class DatabaseSetup
{
    private readonly IMongoDbContext<TaskerDocument> _context;

    public DatabaseSetup(IMongoDbContext<TaskerDocument> context)
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
            Id = 1,
            Title = "Sample Task",
            Description = "A Sample task",
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow
        };

        _context.Collection.InsertOne(tasker);

        //TODO: Seed other data Users, Projects etc
    }
}

