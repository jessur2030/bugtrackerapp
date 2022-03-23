using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerAppLibrary.Models;
public class BasicUserModel
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string FirstName { get; set; }

    public BasicUserModel()
    {

    }

    public BasicUserModel(UserModel user)
    {
        Id = user.Id;
        FirstName = user.FirstName;

    }
}
