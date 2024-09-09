using PizzaMarketService.Models;

namespace PizzaMarketService.Repositories.IPizzaShopRepository
{
	public interface IIngredientInterface
	{
		Task<List<Ingredient>> GET();
		Task<Ingredient> POST(Ingredient ingredient);
		Task<Ingredient> DELETE(int id);
		Task<Ingredient> PUTCH(Ingredient ingredientToUpdate);
		Task<Ingredient> GET(int id);
	}
}
