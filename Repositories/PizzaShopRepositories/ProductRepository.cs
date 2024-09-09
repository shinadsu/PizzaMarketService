using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Data;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class ProductRepository : IProductInterface
	{
		private DataContext _dataContext;
		public ProductRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task DELETE(int id)
		{
			if (id == 0)
				throw new ArgumentException(nameof(id));

			var deleteProduct = await _dataContext.products.FirstOrDefaultAsync(c => c.Id == id);

			_dataContext.products.Remove(deleteProduct);
			await _dataContext.SaveChangesAsync();
		}

		public async Task<List<Product>> GET()
		{
			return await _dataContext.products
				.AsNoTracking()
				.Include(c => c.Ingredients)
				.Include(c => c.Categories)
				.ToListAsync();
		}

		public async Task<Product> GET(int id)
		{
			if (id == 0)
				throw new ArgumentException(nameof(id));

			return await _dataContext.products
				.Include(c => c.Ingredients)
				.Include(c => c.Categories)
				.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task POST(Product product)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));

			await _dataContext.products.AddAsync(product);
			await _dataContext.SaveChangesAsync();
		}

		public async Task PUTCH(Product producttoUpdate)
		{
			if (producttoUpdate == null)
				throw new ArgumentNullException(nameof(producttoUpdate));

			var oldestProduct = await _dataContext.products.FirstOrDefaultAsync(c => c.Id == producttoUpdate.Id);

			if (oldestProduct == null)
				throw new ArgumentException(nameof(oldestProduct));

			oldestProduct.Name = producttoUpdate.Name;
			oldestProduct.Description = producttoUpdate.Description;
			oldestProduct.Price = producttoUpdate.Price;
			oldestProduct.Size = producttoUpdate.Size;
			oldestProduct.Categories = producttoUpdate.Categories;
			oldestProduct.Ingredients = producttoUpdate.Ingredients;
			oldestProduct.ImageURL = producttoUpdate.ImageURL;
			oldestProduct.IsAvailable = producttoUpdate.IsAvailable;

			if (oldestProduct == null)
				throw new ArgumentNullException(nameof(oldestProduct));

			_dataContext.products.Update( oldestProduct );
			await _dataContext.SaveChangesAsync();

		}
	}
}
