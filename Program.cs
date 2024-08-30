using backend.Controllers;
using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Configure DbContext
builder.Services.AddDbContext<UsersStoreContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services.AddControllers();

// Build the app
var app = builder.Build();

// Use CORS
app.UseCors("AllowAll");

// Use routing and map controllers
app.UseRouting();

// Apply migrations on startup
await app.MigrateDbAsync();

 app.MapRegisterController();
// Map controllers
app.MapControllers();

// Run the app
app.Run();
