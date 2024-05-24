using FirstProjectASP.Filters;
using FirstProjectASP.Services;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ActionHistoryService>();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ActionLoggingFilter>();
});

var app = builder.Build();

// Configure logging with NLog

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
