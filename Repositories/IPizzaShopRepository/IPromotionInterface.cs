using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IPromotionInterface
	{
		Task<List<Promotion>> GET();
		Task<Promotion> POST(Review review);
		Task<Promotion> DELETE(int id);
		Task<Promotion> PUTCH(Review reviewtoUpdate);
		Task<Promotion> GET(int id);
	}
}
