using Microsoft.EntityFrameworkCore;
using PizzaService.Data;
using PizzaService.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PizzaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PizzaDbConnectionString")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPizzaEndpoints();

app.Run();

