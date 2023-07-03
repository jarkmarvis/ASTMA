using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ASTMA.Infrastructure.Documents;

public class TaskerDocument
{
    /// <summary>
    /// Unique Id for task
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    /// <summary>
    /// Title of the tasker
    /// </summary>
    [BsonElement("title")]
    public string Title { get; set; }

    /// <summary>
    /// Description of the tasker
    /// </summary>
    [BsonElement("description")]
    public string Description { get; set; }

    /// <summary>
    /// Date tasker was created
    /// </summary>
    [BsonElement("dateCreated")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// Date tasker was updated
    /// </summary>
    [BsonElement("dateModified")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateModified { get; set; }
}

