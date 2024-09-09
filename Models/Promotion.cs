﻿using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class Promotion
	{
		
		public int Id						{ get; set; }
		public string? Title				{ get; set; }
		public string? Description			{ get; set; }
		public decimal? DiscountPercentage	{ get; set; }
		public DateTime StartDate			{ get; set; }
		public DateTime EndDate				{ get; set; }
		public bool isActive				{ get; set; }
	}
}
