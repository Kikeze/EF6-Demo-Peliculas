using Microsoft.EntityFrameworkCore;

using DemoEF6Peliculas;
using System.Text.Json.Serialization;


// Inicializacion
var builder = WebApplication.CreateBuilder(args);

// Variables de la inicializacion
var sConnection = builder.Configuration.GetConnectionString("MainConnection");

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Base de datos
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    {
        options.UseSqlServer(sConnection, server => server.UseNetTopologySuite());
        //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //options.UseLazyLoadingProxies();
    });

// Json
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Automapper
builder.Services.AddAutoMapper(typeof(Program));


// Inicializa la aplicacion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
