using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Configure Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
{
    identityOptions.Password.RequireDigit = false;
    identityOptions.Password.RequiredLength = 8;
    identityOptions.Password.RequireLowercase = true;
    identityOptions.Password.RequireUppercase = true;
    identityOptions.Password.RequireNonAlphanumeric = false;
    identityOptions.Lockout.AllowedForNewUsers = true;
    identityOptions.Lockout.MaxFailedAccessAttempts = 5;
    identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    identityOptions.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
    identityOptions.User.RequireUniqueEmail = true;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Add routing
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the app
app.Run();
