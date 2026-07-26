using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Serilog;
using ServiceVaultWeb.Data;
using ServiceVaultWeb.Repositories;
using ServiceVaultWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
// Register MVC and enable Razor runtime compilation in Development when the package is installed
var mvcBuilder = builder.Services.AddControllersWithViews();
if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}

// DbContext
builder.Services.AddDbContext<ServiceVaultContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceVault")));

// Repositories and services
builder.Services.AddScoped<ICustomerServiceRepository, CustomerServiceRepository>();
builder.Services.AddScoped<ICustomerServiceManager, CustomerServiceManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "ProductOrWarrantyImages")),
    RequestPath = "/ProductOrWarrantyImages"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CustomerServices}/{action=Index}/{id?}");

app.Run();
