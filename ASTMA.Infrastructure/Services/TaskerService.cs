using ASTMA.Application.Common.Interfaces;
using ASTMA.Infrastructure.Documents;
using ASTMA.WebUI.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ASTMA.Infrastructure.Services;

public class TaskerService : ITaskerService
{
    private readonly IMongoCollection<TaskerDocument> _taskerCollection;

    public TaskerService(IOptions<DatabaseSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _taskerCollection = mongoDb.GetCollection<TaskerDocument>(settings.Value.TaskerCollectionName);
    }
}
