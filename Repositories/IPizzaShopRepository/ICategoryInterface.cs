using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface ICategoryInterface
	{
		Task<List<Category>> GET();
		Task<Category> POST(Category category);
		Task<Category> DELETE(int id);
		Task<Category> PUTCH(Category categoryitemUpdate);
		Task<Category> GET(int id);
	}
}
