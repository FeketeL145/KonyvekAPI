using KonyvekFeladat.Models;
using KonyvekFeladat.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<KonyvekContext>();
builder.Services.AddScoped<IKonyvInterface, KonyvekService>();
builder.Services.AddScoped<ISzerzoInterface, SzerzoService>();
builder.Services.AddScoped<ISzerzoNemzetisegInterface, NemzetisegService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
