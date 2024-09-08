using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IUserRepositories
	{
		Task<List<User>> GetAll();
		Task<User> GetById(int id);
		Task Post(User user);
		Task Delete(int id);

	}
}
