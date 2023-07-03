using ASTMA.Application.Common.Interfaces;

namespace ASTMA.Infrastructure.DbContexts;

using MongoDB.Driver;

public class MongoDbContext<T> : IApplicationDbContext<T>
{
    private IMongoClient _client;
    private IMongoDatabase _database;
    private IMongoCollection<T> _collection;

    public IMongoCollection<T> Collection => _collection;
    public IMongoDatabase Database => _database;

    public void Initialize(string connectionString, string databaseName)
    {
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase(databaseName);
        _collection = _database.GetCollection<T>(typeof(T).Name);
    }
}

