using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ASTMA.Infrastructure.Documents;

public class TaskerDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("dateCreated")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }

    [BsonElement("dateModified")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateModified { get; set; }
}

