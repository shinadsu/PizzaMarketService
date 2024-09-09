using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class Order
	{
		public int Id { get; set; }

		// Навигационное свойство
		[JsonIgnore]
		public User? User { get; set; } // Это навигационное свойство указывает на сущность User

		// Внешний ключ
		[ForeignKey("User")]
		public int UserId { get; set; }

		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
		public decimal TotalAmount { get; set; }
		public DateTime OrderDate { get; set; }
		public string? DeliveryAddress { get; set; }
		public string? OrderStatus { get; set; }
		public string? PaymentMethod { get; set; }
	}
}
