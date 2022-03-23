

namespace BugTrackerAppLibrary.Models;
public class CategoryModel
{
    // Identifier
    [BsonId]
    // ObjectId
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
}
