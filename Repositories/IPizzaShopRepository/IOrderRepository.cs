using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IOrderRepository
	{
		Task<List<Order>> Get();
		Task<Order> GetWithid(int id);
		Task post(Order order);
		Task put(Order order);
		Task delete(int id);

	}
}
