

namespace BugTrackerAppLibrary.Models;
//BasicIssueModel: SubObject stored in user model
public class BasicIssueModel
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Issue { get; set; }

    //BasicIssueModel() Blank contructor: Allows us to create this object on  its own
    //without having to have data pass into it.
    public BasicIssueModel()
    {

    }

    //BasicIssueModel()  contructor: Pass in IssueModel: and called issue
    public BasicIssueModel(IssueModel  issue)
    {
        //Stores the basic issue model : from IssuesModel
        Id = issue.Id;
        Issue = issue.Issue;
    }
}
