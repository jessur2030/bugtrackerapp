using MongoDB.Driver;

namespace BugTrackerAppLibrary.DataAccess;

public interface IDbConnection
{
    IMongoCollection<CategoryModel> CategoryCollection { get; }
    string CategoryCollectionName { get; }
    MongoClient Client { get; }
    string DbName { get; }
    IMongoCollection<IssueModel> IssueCollection { get; }
    string IssueCollectionName { get; }
    IMongoCollection<StatusModel> StatusCollection { get; }
    string StatusCollectionName { get; }
    IMongoCollection<UserModel> UserCollection { get; }
    string UserCollectionName { get; }
}