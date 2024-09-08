using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IFastfoodRepository
	{
		Task<List<Fastfood>> GetFastfoods();
		Task<Fastfood> GetFastfood(int id);
		Task AddAsync(Fastfood fastfood);
		Task DeleteAsync(int id);
	}
}
