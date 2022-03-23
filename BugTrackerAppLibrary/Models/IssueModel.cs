
namespace BugTrackerAppLibrary.Models;
public class IssueModel
{

// Identifier
[BsonId]
// ObjectId
[BsonRepresentation(BsonType.ObjectId)]
public string Id { get; set; }
//public string IssueType { get; set; }
public string Issue { get; set; }
public string Description { get; set; }
public string Status { get; set; }
public string Priority { get; set; }
public DateTime DateCreated { get; set; } = DateTime.UtcNow;

//Allows us to know in what category new issue are 
public CategoryModel Category { get; set; }
public BasicUserModel Author { get; set; }
public StatusModel IssueStatus { get; set; }
public string Notes { get; set; }
public bool Archived { get; set; } = false;
}
