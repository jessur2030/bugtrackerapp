namespace BugTrackerUI;

//Dependencies injection configurations
public static class RegisterServices
    //Configure our dependency injections
{
    //Extention method: ConfigureDependencyInjection()
    public static void ConfigureDependencyInjection(this WebApplicationBuilder builder)
    {
      
        // Dependencies injection configuration
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddMemoryCache();

    }

}
