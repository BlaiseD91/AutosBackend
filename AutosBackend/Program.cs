using AutosBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

Adatbazis<Jarmu> adatbazis = new Adatbazis<Jarmu>();
foreach (var item in adatbazis.AddIde())
{
    Console.WriteLine(item==null?"Még nincs benne jármû":item);
}
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Jarmuvek>(
    o=>o.UseInMemoryDatabase("Jarmuvek")
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
