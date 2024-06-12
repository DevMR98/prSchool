using Microsoft.EntityFrameworkCore;
using prSchool.DTOs;
using prSchool.Models;
using prSchool.Repository;
using prSchool.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//inyeccion de las bd
builder.Services.AddDbContext<SchoolContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnectionH"));
});
//inyeccion repository
builder.Services.AddScoped<IStudentRepository<Student>, StudentRepository>();
//inyeccion de service
builder.Services.AddScoped<IStudentService<StudentDto>, StudentService>();


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