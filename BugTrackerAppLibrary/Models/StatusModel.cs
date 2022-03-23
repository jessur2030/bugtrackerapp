
namespace BugTrackerAppLibrary.Models;
public class StatusModel
{

    // Identifier
    [BsonId]
    // ObjectId
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string StatusName { get; set; }
    public string StatusDescription { get; set; }


}
