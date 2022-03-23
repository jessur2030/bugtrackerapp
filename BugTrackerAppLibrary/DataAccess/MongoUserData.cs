

namespace BugTrackerAppLibrary.DataAccess;
public class MongoUserData : IUserData
{
    //type:userModal : called _users
    //create a copy from the referance to the object UserModel
    private readonly IMongoCollection<UserModel> _users;

    //create constructor MongoUserData:  Ask for IDbConnection as db
    public MongoUserData(IDbConnection db)
    {
        //get db connection for the users
        _users = db.UserCollection;
    }

    // @Desc: get all users method 
    public async Task<List<UserModel>> GetUsersAsync()
    {
        //find all record: where _ => true:  return all records from users 
        var results = await _users.FindAsync(_ => true);
        //RETURN all users list asynchronously
        return results.ToList();
    }

    // @Desc: get single user method 
    public async Task<UserModel> GetUser(string id)
    {
        //look base on user mongoDB Identifier
        var results = await _users.FindAsync(u => u.Id == id);
        return results.FirstOrDefault();

    }

    // @Desc: Get User From Authentication
    public async Task<UserModel> GetUserFromAuthentication(string objectId)
    {
        //look for user base on Azure active derectory ObjectIdentifier
        var results = await _users.FindAsync(u => u.ObjectIdentifier == objectId);
        return results.FirstOrDefault();

    }

    // @Desc: create a new user method 
    public Task CreateUser(UserModel user)
    {
        //Insert new created user into our db users collection
        return _users.InsertOneAsync(user);
    }

    // @Desc: Update user method 
    public Task UpdateUser(UserModel user)
    {
        //Creates a filter for mathing the Id to the user.Id
        var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
        // find filter object that math their Id, and repalce it with user
        // IsUpsert: if found no entry for that user: Perform an insert : If it founds one, Do an update
        return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });

    }

}
