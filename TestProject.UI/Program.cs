using Microsoft.EntityFrameworkCore;
using TestProject.Infrastructure.Data;
using TestProject.Application.Abstraction.DbContext;
using IDOCS.Api.Extensions;
using System.Security.Claims;
using TestProject.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("Cookie")
              .AddCookie("Cookie", config =>
              {
                  config.LoginPath = "/Account/Login";
                  config.AccessDeniedPath = "/Account/AccessDenied";
                  config.SlidingExpiration = true;
                  config.ExpireTimeSpan = new TimeSpan(0, 24, 0, 0);
              });
builder.Services.AddAuthorization(
    options =>
    {
        options.AddPolicy("Administrator", builder =>
        {
            builder.RequireClaim(ClaimTypes.Role, "Administrator");
        });
        options.AddPolicy("StandardUser", builder =>
        {
            builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "StandardUser")
                                            || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
        });
    });

//database
string connectionString = builder.Configuration.GetConnectionString("EssentialConnectionString");
builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.RegisterCustomServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MigrateDbContext<AppDbContext>((context, services) =>
{
    context.Database.Migrate();
});
//Seed database
AppDbInitializer.Seed(app);

app.Run();
