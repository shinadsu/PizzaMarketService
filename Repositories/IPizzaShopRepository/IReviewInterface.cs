using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IReviewInterface
	{
		Task<List<Review>> GET();
		Task<Review> POST(Review review);
		Task<Review> DELETE(int id);
		Task<Review> PUTCH(Review reviewtoUpdate);
		Task<Review> GET(int id);
	}
}
