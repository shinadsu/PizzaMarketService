using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Data;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class PizzaRepository : IPizzaRepository
	{
		private DataContext _dataContext;

		public PizzaRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task AddAsync(Pizza pizza)
		{
			await _dataContext.pizzas.AddAsync(pizza); // Добавляем пиццу
			await _dataContext.SaveChangesAsync(); // Сохраняем изменения
		}

		public async Task DeleteAsync(int id)
		{
			var pizza = await _dataContext.pizzas.FindAsync(id);
			if (pizza != null)
			{
				_dataContext.pizzas.Remove(pizza);
				await _dataContext.SaveChangesAsync(); // Должно быть await
			}
		}

		public async Task<Pizza> GetPizza(int id)
		{
			return await _dataContext.pizzas.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<List<Pizza>> GetPizzas()
		{
			return await _dataContext.pizzas.ToListAsync();
		}

	}
}
