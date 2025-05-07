using BinaryConverterAPI.Data;
using BinaryConverterAPI.Data.Interfaces;
using BinaryConverterAPI.Data.Repositories;
using BinaryConverterAPI.Services;
using Microsoft.EntityFrameworkCore;
using BinaryConverterAPI.Middleware;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<BinaryService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});



//Conexion a la base datos - APPDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=DESKTOP-HDC0QQP;Database=ConversionsDb;Trusted_Connection=True;TrustServerCertificate=True;"));


//Intefaces
builder.Services.AddScoped<IUOW, UOW>();
builder.Services.AddScoped<IBinaryService, BinaryService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable middleware to serve Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

// ?? AGREGÁ ESTE MIDDLEWARE
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();
app.MapControllers();


app.Run();
