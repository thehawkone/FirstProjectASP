using FirstProjectASP.Filters;
using FirstProjectASP.Services;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    logger.Debug("init main");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container + configure NLog
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();
    builder.Services.AddRazorPages();
    builder.Services.AddSingleton<ActionHistoryService>();
    builder.Services.AddControllersWithViews(options => { options.Filters.Add<ActionLoggingFilter>(); });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id:int?}");
    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception: ");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
