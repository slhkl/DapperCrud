using DapperCrud.Business.Service.Concrete;
using DapperCrud.Business.Service.Discrete;
using DapperCrud.Data.Model;
using DapperCrud.DataAccess.Repository.Concrete;
using DapperCrud.DataAccess.Repository.Discrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IRepository<Company>, CompanyRepository>();
builder.Services.AddSingleton<IService<Company>, CompanyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
