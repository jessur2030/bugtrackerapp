

using Microsoft.Extensions.Caching.Memory;

namespace BugTrackerAppLibrary.DataAccess;
public class MongoCategoryData : ICategoryData
{
    //
    private readonly IMongoCollection<CategoryModel> _categories;
    //
    private readonly IMemoryCache _cache;
    //CategoryData: name usse for our category data cashing
    private const string cacheName = "CategoryData";

    //get from dependency injection: IDbConnection as db,
    //and IMemoryCache as cache 
    public MongoCategoryData(IDbConnection db, IMemoryCache cache)
    {
        _cache = cache;
        //
        _categories = db.CategoryCollection;
    }

    //Gather all differents methods we need for CategoryData

    //GetAllCategories method
    public async Task<List<CategoryModel>> GetAllCategories()
    {
        //ask cache for CategoryData (cacheName)
        var output = _cache.Get<List<CategoryModel>>(cacheName);
        //if there is no cache
        if (output is null)
        {
            //find all categories from our db
            var result = await _categories.FindAsync(_ => true);
            output = result.ToList();

            //put category data in cache: keep in cache for 1 day, and get a new cache list every day
            _cache.Set(cacheName, output, TimeSpan.FromDays(1));
        }
        // output
        return output;


    }

    //For initial setup our db
    public Task CreateCategory(CategoryModel category)
    {
        return _categories.InsertOneAsync(category);
    }

}
