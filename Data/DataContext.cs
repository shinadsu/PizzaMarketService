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
		public DbSet<Product> products			{ get; set; }
		public DbSet<OrderItem> orderItems		{ get; set; }
		public DbSet<Order> orders				{ get; set; }
		public DbSet<Ingredient> ingredients	{ get; set; }
		public DbSet<Category> categories		{ get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.HasMany(p => p.Categories)
				.WithMany()
				.UsingEntity(j => j.ToTable("ProductCategory"));


			modelBuilder.Entity<Product>()
				.HasMany(p => p.Ingredients)
				.WithMany()
				.UsingEntity(j => j.ToTable("ProductIngredients"));


			modelBuilder.Entity<Order>()
				.HasMany(c => c.OrderItems)
				.WithMany()
				.UsingEntity(j => j.ToTable("OrderOrderItems"));

			modelBuilder.Entity<Order>()
				.HasOne(c => c.User)
				.WithMany()
				.HasForeignKey(c => c.UserId);

			modelBuilder.Entity<OrderItem>()
			   .HasOne( o => o.product ) 
			   .WithMany() 
			   .HasForeignKey( o => o.ProductID ); 


			base.OnModelCreating(modelBuilder);
		}

	}	
}
