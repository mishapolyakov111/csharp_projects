using Itmo.ObjectOrientedProgramming.Lab5.Application.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication()
    .AddInfrastructureDataAccess("Server=localhost;Port=5432;Database=Lab5;Username=postgres;Password=198330;")
    .AddControllersWithViews();

WebApplication app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();