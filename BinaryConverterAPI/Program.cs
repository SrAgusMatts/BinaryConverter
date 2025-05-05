using BinaryConverterAPI.Data;
using BinaryConverterAPI.Data.Interfaces;
using BinaryConverterAPI.Data.Repositories;
using BinaryConverterAPI.Services;
using Microsoft.EntityFrameworkCore;
using BinaryConverterAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<BinaryService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Conexion a la base datos - APPDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=conversions.db"));

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
