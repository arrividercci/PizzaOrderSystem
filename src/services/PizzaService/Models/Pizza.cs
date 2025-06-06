﻿namespace PizzaService.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public Categories Category { get; set; }
    }
}
