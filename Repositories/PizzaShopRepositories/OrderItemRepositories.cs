using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class OrderItemRepositories : IOrderItemInterface
	{
		public Task<OrderItem> DELETE(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<OrderItem>> GET()
		{
			throw new NotImplementedException();
		}

		public Task<OrderItem> GET(int id)
		{
			throw new NotImplementedException();
		}

		public Task<OrderItem> POST(OrderItem orderItem)
		{
			throw new NotImplementedException();
		}

		public Task<OrderItem> PUTCH(OrderItem orderItemtoUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
