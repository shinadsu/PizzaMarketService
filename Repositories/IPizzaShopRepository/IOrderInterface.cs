using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IOrderInterface
	{
		Task<List<Order>> GET();
		Task POST(Order order);
		Task DELETE(int id);
		Task PUTCH(Order ordertoUpdate);
		Task<Order> GET(int id);
	}
}
