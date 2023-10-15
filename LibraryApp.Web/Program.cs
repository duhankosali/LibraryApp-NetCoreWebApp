using LibraryApp.Core.Repositories;
using LibraryApp.Core.Services;
using LibraryApp.Core.UnitOfWorks;
using LibraryApp.Repository;
using LibraryApp.Repository.Repositories;
using LibraryApp.Repository.UnitOfWorks;
using LibraryApp.Service.Mapping;
using LibraryApp.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

// - My Services
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Scopeds:
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // for Repository Layer 
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>)); // for Business Layer
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

// Automapper
builder.Services.AddAutoMapper(typeof(MapProfile));

// Connection Database:

// ***Environment tanýmlayarak projeyi ayaða kaldýrmak için: (Environment tanýmlamasýný IDE'nizi açmadan önce yapmanýz tavsiye edilir)
string connectionString = Environment.GetEnvironmentVariable("MSSQL_CONNECTION_STRING"); // Open CMD --> setx MSSQL_CONNECTION_STRING "YOUR_CONNECTION_STRING" (windows)
                                                                                         // Open Console --> export MSSQL_CONNECTION_STRING="YOUR_CONNECTION_STRING" (linux, mac)

// ***Eðer environment tanýmlarken problem yaþýyorsanýz yukarýyý yoruma alýp connectionString'i alttaki satýra yapýþtýrabilirsiniz.
//string connectionString = "YOUR_CONNECTION_STRING" 

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
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
