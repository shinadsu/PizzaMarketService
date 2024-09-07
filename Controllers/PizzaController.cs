using Microsoft.AspNetCore.Mvc;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PizzaController : ControllerBase
	{
		private IPizzaRepository _pizzaRepository;
		public PizzaController(IPizzaRepository pizzaRepository)
		{
			_pizzaRepository = pizzaRepository;
		}

		[HttpGet(Name = "GetPizzasAsync")]
		public async Task<List<Pizza>> GetPizzasAsync()
		{
			return await _pizzaRepository.GetPizzas();
		}

		[HttpGet("id:int")]
		public async Task<Pizza> GetPizza(int id)
		{
			return await _pizzaRepository.GetPizza(id);
		}

		[HttpPost(Name = "AddPizzaAsync")]
		public async Task AddPizzaAsync(Pizza pizza)
		{
			if (pizza == null)
				throw new ArgumentNullException(nameof(pizza));
			

			if (ModelState.IsValid)
			{
				try
				{
					await _pizzaRepository.AddAsync(pizza);
				}
				catch (Exception ex)
				{

					throw new Exception(ex.Message);
				}
			}
		}

		[HttpDelete("id:int")]
		[IgnoreAntiforgeryToken]
		public async Task DeletePizza(int id)
		{
			if (id == 0)
				throw new ArgumentNullException(nameof(id));

			try
			{
				await _pizzaRepository.DeleteAsync(id);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
	}
}
