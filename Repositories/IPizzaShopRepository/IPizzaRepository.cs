using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IPizzaRepository
	{
		Task<List<Pizza>> GetPizzas();
		Task<Pizza> GetPizza(int id);
		Task AddAsync(Pizza pizza);
		Task DeleteAsync(int id);
	}
}
