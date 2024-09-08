﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class User
	{
		[JsonIgnore]
		public int Id						{ get; set; }
		public string? Name					{ get; set; }
		public string? Email				{ get; set; }
		public string? PasswordHash			{ get; set; }
		public string? Role					{ get; set; }
		public string? Address				{ get; set; }
		public string? PhoneNumber			{ get; set; }
		public List<Order>? OrderHistory	{ get; set; }
	}
}
