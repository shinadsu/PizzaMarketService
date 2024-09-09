using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public decimal? Price { get; set; }
		public string? Size { get; set; }
		public List<Category>? Categories { get; set; } = new List<Category>();
		public List<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
		public string? ImageURL { get; set; }
		public bool? IsAvailable { get; set; }

	}
}
