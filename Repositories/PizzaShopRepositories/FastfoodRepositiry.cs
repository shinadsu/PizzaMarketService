using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Data;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class FastfoodRepositiry : IFastfoodRepository
	{
		private DataContext _dataContext;

		public FastfoodRepositiry(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task AddAsync(Fastfood fastfood)
		{
			await _dataContext.fastfoods.AddAsync(fastfood);
			await _dataContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var pizza = await _dataContext.fastfoods.FindAsync(id);
			if (pizza != null)
			{
				_dataContext.fastfoods.Remove(pizza);
				await _dataContext.SaveChangesAsync(); // Должно быть await
			}
		}
		public async Task<Fastfood> GetFastfood(int id)
		{
			return await _dataContext.fastfoods.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<List<Fastfood>> GetFastfoods()
		{
			return await _dataContext.fastfoods
				.Include(f => f.ingredients)   // Включение ингредиентов
				.Include(f => f.Categorys)      // Включение категории
				.ToListAsync();
		}

	}
}
