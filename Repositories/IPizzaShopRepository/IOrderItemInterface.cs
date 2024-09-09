using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IOrderItemInterface
	{
		Task<List<OrderItem>> GET();
		Task<OrderItem> POST(OrderItem orderItem);
		Task<OrderItem> DELETE(int id);
		Task<OrderItem> PUTCH(OrderItem orderItemtoUpdate);
		Task<OrderItem> GET(int id);
	}
}
