

using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BugTrackerAppLibrary.DataAccess;
//start connection with MangoDB
//Singlenton class
public class DbConnection : IDbConnection
{

    //
    private readonly IConfiguration _config;
    //create _db: our database connection to mangoDB
    private readonly IMongoDatabase _db;
    //
    private string _connectionId = "MongoDB";
    //db name
    public string DbName { get; private set; }
    //category collection
    public string CategoryCollectionName { get; private set; } = "categories";
    //status collection
    public string StatusCollectionName { get; private set; } = "statuses";
    //users collection
    public string UserCollectionName { get; private set; } = "users";
    //issues collection
    public string IssueCollectionName { get; private set; } = "issus";

    //Mongo Client
    public MongoClient Client { get; private set; }

    //Mongo collections
    //IMongoCollection: type: CategoryModel
    public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
    //IMongoCollection: type: StatusModel
    public IMongoCollection<StatusModel> StatusCollection { get; private set; }
    //IMongoCollection: type: UserCollection
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    //IMongoCollection: type: IssueCollection
    public IMongoCollection<IssueModel> IssueCollection { get; private set; }

    //create contructor, and get the configuration
    public DbConnection(IConfiguration config)
    {
        _config = config;
        //create new client
        Client = new MongoClient(_config.GetConnectionString(_connectionId));
        //coneections to our  
        DbName = _config["DatabaseName"];
        //
        _db = Client.GetDatabase(DbName);

        //create a connection to our collections
        CategoryCollection = _db.GetCollection<CategoryModel>(CategoryCollectionName);
        StatusCollection = _db.GetCollection<StatusModel>(StatusCollectionName);
        UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
        IssueCollection = _db.GetCollection<IssueModel>(IssueCollectionName);
    }
}
