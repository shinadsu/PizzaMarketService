using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class ReviewRepository : IReviewInterface
	{
		public Task<Review> DELETE(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Review>> GET()
		{
			throw new NotImplementedException();
		}

		public Task<Review> GET(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Review> POST(Review review)
		{
			throw new NotImplementedException();
		}

		public Task<Review> PUTCH(Review reviewtoUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
