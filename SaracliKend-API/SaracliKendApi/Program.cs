using Microsoft.AspNetCore.Identity;
using SaracliKend.Application;
using SaracliKend.Database;
using SaracliKend.Database.Context;
using SaracliKend.Domain.Entities;
using SaracliKend.Infrastructure.Resources;
using SaracliKendApi.Areas.AdminPanel.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;
}).AddEntityFrameworkStores<SaracliDbContext>().AddDefaultTokenProviders();

Constants.ImageFolderPath = Path.Combine(builder.Environment.WebRootPath, "img");
Constants.VideoFolderPath = Path.Combine(builder.Environment.WebRootPath, "video");

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

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
           name: "AdminPanel",
           areaName: "AdminPanel",
           pattern: "adminPanel/{controller=Dashboard}/{action=Index}/{id?}"
       );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SaracliDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var dataInitializer = new DataInitializer(dbContext, roleManager, userManager);
    await dataInitializer.SeedData();
}

app.Run();