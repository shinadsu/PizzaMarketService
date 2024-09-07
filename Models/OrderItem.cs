using Microsoft.AspNetCore.Mvc;

namespace PizzaMarketService.Models
{
	public class OrderItem
	{
		
		public int Id							{ get; set; }
		public int Name							{ get; set; }
		public int PizzaId						{ get; set; }
		public int Quantity						{ get; set; }
		public decimal UnitPrice				{ get; set; }
		
	}
}
