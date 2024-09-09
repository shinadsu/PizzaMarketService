using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class OrderItem
	{
		public int Id							{ get; set; }
		public int OrderId						{ get; set; }

		[JsonIgnore]
		public Product? product					{ get; set; } // Это навигационное свойство указывает на сущность Product

		[ForeignKey("Product")]
		public int ProductID					{ get; set; }

		public int Quantity						{ get; set; }
		public decimal UnitPrice				{ get; set; }
		
	}
}
