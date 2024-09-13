using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace PizzaMarketService.Models
{
	public class User
	{
		public int Id					{ get; set; }
		public string? Name				{ get; set; }
		public string? Email				{ get; set; }
		public byte[] PasswordHash			{ get; set; } = new byte[32];
	        public string? Role	                        { get; set; }
		public string? Address				{ get; set; }
		public string? PhoneNumber			{ get; set; }
	}
}
