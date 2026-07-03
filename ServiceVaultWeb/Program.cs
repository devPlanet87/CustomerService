using Microsoft.EntityFrameworkCore;
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
builder.Services.AddControllersWithViews();

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CustomerServices}/{action=Index}/{id?}");

app.Run();
