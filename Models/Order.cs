using Microsoft.AspNetCore.Mvc;

namespace PizzaMarketService.Models
{
	public class Order
	{
		public int Id							{ get; set; }
		public int UserId						{ get; set; }
		public List<OrderItem> OrderItems		{ get; set; } = new List<OrderItem>();
		public decimal TotalAmount				{ get; set; }
		public DateTime OrderDate				{ get; set; }
		public string? DeliveryAddress			{ get; set; }
		public string? OrderStatus				{ get; set; }
		public string? PaymentMethod			{ get; set; }
	}
}
