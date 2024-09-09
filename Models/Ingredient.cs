using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class Ingredient
	{
		public int Id							{ get; set; }
		public string? Name						{ get; set; }
		public string? Description				{ get; set; }
		public bool IsAvailable					{ get; set; }
	}
}
