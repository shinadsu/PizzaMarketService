using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class Review
	{
		[JsonIgnore]
		public int Id				{ get; set; }
		public int PizzaId			{ get; set; }
		public int UserId			{ get; set; }
		public int Rating			{ get; set; }
		public string? comment		{ get; set; }
		public DateTime ReviewDate	{ get; set; }	

	}
}
