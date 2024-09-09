using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class IngredientRepositories : IIngredientInterface
	{
		public Task<Ingredient> DELETE(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Ingredient>> GET()
		{
			throw new NotImplementedException();
		}

		public Task<Ingredient> GET(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Ingredient> POST(Ingredient ingredient)
		{
			throw new NotImplementedException();
		}

		public Task<Ingredient> PUTCH(Ingredient ingredientToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
