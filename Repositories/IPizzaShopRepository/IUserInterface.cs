using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IUserInterface
	{
		Task<List<User>> GET();
		Task POST(User user);
		Task DELETE(int id);
		Task PUTCH(User usertoUpdate);
		Task<User> GET(int id);

	}
}
