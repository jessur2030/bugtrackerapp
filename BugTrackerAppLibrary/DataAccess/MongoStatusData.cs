

using Microsoft.Extensions.Caching.Memory;

namespace BugTrackerAppLibrary.DataAccess;
public class MongoStatusData : IStatusData
{
    private readonly IMongoCollection<StatusModel> _statuses;
    private readonly IMemoryCache _cache;
    //cacheName for MongoStatusData
    private const string cacheName = "StatusData";


    public MongoStatusData(IDbConnection db, IMemoryCache cache)
    {
        _cache = cache;
        _statuses = db.StatusCollection;
    }


    //Gather all differents methods we need for MongoStatusData

    public async Task<List<StatusModel>> GetAllStatuses()
    {
        //
        var output = _cache.Get<List<StatusModel>>(cacheName);

        //if no cache is found
        if (output is null)
        {
            //
            var results = await _statuses.FindAsync(_ => true);
            //return results lsit
            output = results.ToList();

            //put statuses data in cache: keep in cache for a full day, and get a new cache list every day
            _cache.Set(cacheName, output, TimeSpan.FromDays(1));
        }
        return output;
    }


    //For initial setup for our db only
    public Task CreateStatus(StatusModel status)
    {
        return _statuses.InsertOneAsync(status);
    }


}
