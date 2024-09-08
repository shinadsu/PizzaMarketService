using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Data;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class OrderRepository : IOrderRepository
	{	
		private DataContext _dataContext;
		public OrderRepository(DataContext dataContext) 
		{
			_dataContext = dataContext;
		}
		public async Task delete(int id)
		{
			var orderToDelete = await _dataContext.orders.FirstOrDefaultAsync(x => x.Id == id);

			if (orderToDelete == null)
			{
				throw new KeyNotFoundException("Order not found");
			}

			_dataContext.orders.Remove(orderToDelete);
			await _dataContext.SaveChangesAsync();
		}


		public async Task<List<Order>> Get()
		{
			return await _dataContext.orders.AsNoTracking().ToListAsync();
		}

		public async Task<Order> GetWithid(int id)
		{
			return await _dataContext.orders.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task post(Order order)
		{
			await _dataContext.orders.AddAsync(order);  
			await _dataContext.SaveChangesAsync();  
		}

		public Task put(Order order)
		{
			throw new NotImplementedException();
		}
	}
}
