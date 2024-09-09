using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IProductInterface
	{
		Task<List<Product>> GET();
		Task POST(Product product);
		Task DELETE(int id);
		Task PUTCH(Product producttoUpdate);
		Task<Product> GET(int id);
	}
}
