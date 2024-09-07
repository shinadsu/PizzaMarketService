using Microsoft.AspNetCore.Mvc;

namespace PizzaMarketService.Models
{
	public class Pizza
	{
		public int Id							{ get; set; }
		public string? Name						{ get; set; }
		public string? Description				{ get; set; }
		public decimal Price					{ get; set; }
		public string? Size						{ get; set; }
		public int CategoryId					{ get; set; }
		public List<Ingredient>? ingredients	{ get; set; }
		public string? ImageURL					{ get; set; }
		public bool IsAvailable					{ get; set; }
	}
}
