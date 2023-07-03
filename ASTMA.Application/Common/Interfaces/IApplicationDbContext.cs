using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTMA.Application.Common.Interfaces;

public interface IApplicationDbContext<T>
{
    IMongoCollection<T> Collection { get; }
    IMongoDatabase Database { get; }

    void Initialize(string connectionString, string databaseName);
}
