
namespace BugTrackerAppLibrary.Models;
public class UserModel

{
    // Identifier
    [BsonId]
    // ObjectId
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    //Azure active directory ObjectIdentifier
    public string ObjectIdentifier { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAdress { get; set; }

    //list of issues that user has created
    public List<BasicIssueModel> AuthoredIssues { get; set; } = new();


}
