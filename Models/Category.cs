using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class Category
	{
		public int Id		{ get; set; }
		public string? Name { get; set; }
	}
}
