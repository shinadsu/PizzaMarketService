using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Data;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class OrderRepositories : IOrderInterface
	{
		private DataContext _datacontext;
		public OrderRepositories(DataContext dataContext) 
		{
			_datacontext = dataContext;
		}
		public async Task DELETE(int id)
		{
			if ( id == 0 )
				throw new ArgumentException( nameof( id ) );

			var deletedOrder = await _datacontext.orders.FirstOrDefaultAsync(c => c.Id == id);

			_datacontext.orders.Remove( deletedOrder );
			await _datacontext.SaveChangesAsync();
		}

		public async Task<List<Order>> GET()
		{
			return await _datacontext.orders
				.Include(c => c.OrderItems)
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<Order> GET(int id)
		{
			if ( id == 0 )
				throw new ArgumentException( nameof( id ) );

			return await _datacontext.orders.FirstOrDefaultAsync( c => c.Id == id );
		}

		public async Task POST(Order order)
		{
			if ( order == null )
				throw new ArgumentNullException( nameof( order ) );

			await _datacontext.orders.AddAsync( order );
			await _datacontext.SaveChangesAsync();
		}

		public async Task PUTCH(Order ordertoUpdate)
		{
			if ( ordertoUpdate == null )
				throw new ArgumentNullException( nameof( ordertoUpdate ) );

			var ordertoPatch = await _datacontext.orders
				.Include(o => o.OrderItems) 
				.FirstOrDefaultAsync(c => c.Id == ordertoUpdate.Id);

			if ( ordertoPatch == null )
				throw new ArgumentNullException( nameof( ordertoPatch ) );

			// Обновляем простые поля
			ordertoPatch.UserId = ordertoUpdate.UserId;
			ordertoPatch.TotalAmount = ordertoUpdate.TotalAmount;
			ordertoPatch.OrderDate = ordertoUpdate.OrderDate;
			ordertoPatch.DeliveryAddress = ordertoUpdate.DeliveryAddress;
			ordertoPatch.OrderStatus = ordertoUpdate.OrderStatus;
			ordertoPatch.PaymentMethod = ordertoUpdate.PaymentMethod;

			// Обновляем OrderItems
			_datacontext.Entry( ordertoPatch ).Collection( o => o.OrderItems ).Load(); // Загружаем существующие OrderItems

			
			foreach ( var existingItem in ordertoPatch.OrderItems.ToList() )
			{
				if ( !ordertoUpdate.OrderItems.Any( o => o.Id == existingItem.Id ) )
				{
					_datacontext.orderItems.Remove( existingItem );
				}
			}

			// Добавляем или обновляем OrderItems
			foreach ( var updatedItem in ordertoUpdate.OrderItems )
			{
				var existingItem = ordertoPatch.OrderItems
					.FirstOrDefault(o => o.Id == updatedItem.Id);

				if ( existingItem != null )
				{
					// Обновляем существующий элемент
					existingItem.OrderId = updatedItem.OrderId;
					existingItem.ProductID = updatedItem.ProductID;
					existingItem.Quantity = updatedItem.Quantity;
					existingItem.UnitPrice = updatedItem.UnitPrice;
				}
				else
				{
					// Добавляем новый элемент
					ordertoPatch.OrderItems.Add( updatedItem );
				}
			}

			_datacontext.orders.Update( ordertoPatch );
			await _datacontext.SaveChangesAsync();
		}
	}
}
