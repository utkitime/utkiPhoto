using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UtkiPhoto.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UtkiPhotoContext>(options =>
    options.UseSqlite("Data Source=utkiphoto.db"));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<UtkiPhotoContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("UtkiPhotoContext")));
}
else
{
    builder.Services.AddDbContext<UtkiPhotoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionUtkiPhotoContext")));
}

// Add services to the container.
builder.Services.AddControllersWithViews();

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
