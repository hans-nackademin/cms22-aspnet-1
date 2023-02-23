using _02_ProfileAndImageUpload.Models.Contexts;
using _02_ProfileAndImageUpload.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AuthenticationHandler>();
builder.Services.AddScoped<ProfileHandler>();
builder.Services.AddScoped<LocalFileUpload>();
builder.Services.AddScoped<CloudFileUpload>();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();
builder.Services.ConfigureApplicationCookie(x => { x.LoginPath = "/account/signin"; });



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
