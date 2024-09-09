using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class CategoryRepositories : ICategoryInterface
	{
		public Task<Category> DELETE(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Category>> GET()
		{
			throw new NotImplementedException();
		}

		public Task<Category> GET(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Category> POST(Category category)
		{
			throw new NotImplementedException();
		}

		public Task<Category> PUTCH(Category categoryitemUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
