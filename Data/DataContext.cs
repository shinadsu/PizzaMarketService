using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Models;

namespace PizzaMarketService.Data
{	


	public class DataContext : DbContext
	{
		
		public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{
			
		}

		public DbSet<User> users				{ get; set; }
		public DbSet<Review> reviews			{ get; set; }
		public DbSet<Promotion> promotions		{ get; set; }
		public DbSet<Pizza> pizzas				{ get; set; }
		public DbSet<OrderItem> orderItems		{ get; set; }
		public DbSet<Order> orders				{ get; set; }
		public DbSet<Ingredient> ingredients	{ get; set; }
		public DbSet<Category> categories		{ get; set; }


	}
}
