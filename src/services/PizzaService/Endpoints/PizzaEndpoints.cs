using Microsoft.EntityFrameworkCore;
using PizzaService.Data;
using PizzaService.Models;

namespace PizzaService.Endpoints
{
    public static class PizzaEndpoints
    {
        public static WebApplication MapPizzaEndpoints(this WebApplication app)
        {
            var pizzas = app.MapGroup("/api/pizzas");
            pizzas.MapGet("/", GetAllPizzas);
            pizzas.MapGet("/{id:int}", GetPizzaById);
            pizzas.MapPost("/", CreatePizza);
            pizzas.MapPut("/{id:int}", UpdatePizza);
            pizzas.MapDelete("/{id:int}", DeletePizza);
            return app;
        }

        private static async Task<IResult> GetAllPizzas(PizzaDbContext db)
        {
            var list = await db.Pizzas.ToListAsync();
            return Results.Ok(list);
        }

        private static async Task<IResult> GetPizzaById(int id, PizzaDbContext db)
        {
            var pizza = await db.Pizzas.FindAsync(id);
            return pizza is not null ? Results.Ok(pizza) : Results.NotFound();
        }

        private static async Task<IResult> CreatePizza(Pizza newPizza, PizzaDbContext db)
        {
            db.Pizzas.Add(newPizza);
            await db.SaveChangesAsync();
            return Results.Created($"/api/pizzas/{newPizza.Id}", newPizza);
        }

        private static async Task<IResult> UpdatePizza(int id, Pizza updatedPizza, PizzaDbContext db)
        {
            if (id != updatedPizza.Id)
                return Results.BadRequest(new { Error = "Id в URL і в тілі не співпадають" });

            var existing = await db.Pizzas.FindAsync(id);
            if (existing is null)
                return Results.NotFound();

            existing.Name = updatedPizza.Name;
            existing.Description = updatedPizza.Description;
            existing.Price = updatedPizza.Price;
            existing.Category = updatedPizza.Category;
            existing.ImageUrl = updatedPizza.ImageUrl;

            await db.SaveChangesAsync();
            return Results.NoContent();
        }

        private static async Task<IResult> DeletePizza(int id, PizzaDbContext db)
        {
            var pizza = await db.Pizzas.FindAsync(id);
            if (pizza is null)
                return Results.NotFound();

            db.Pizzas.Remove(pizza);
            await db.SaveChangesAsync();
            return Results.NoContent();
        }
    }
}
