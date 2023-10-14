using LibraryApp.Core.Repositories;
using LibraryApp.Core.UnitOfWorks;
using LibraryApp.Repository;
using LibraryApp.Repository.Repositories;
using LibraryApp.Repository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

// - My Services
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Scopeds:
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Connection Database:
string connectionString = "server=(localdb)\\mssqllocaldb; database=libraryDb; integrated security=true;"; // temporary local db.
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connectionString, option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// - My Middlewares
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
