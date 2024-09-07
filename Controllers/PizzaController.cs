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

		[HttpGet]
		public async Task<List<Pizza>> GetPizzasAsync()
		{
			var res = await _pizzaRepository.GetPizzas();
            Console.WriteLine(res);
			return await _pizzaRepository.GetPizzas();
		}

		[HttpGet("id")]
		public async Task<Pizza> GetPizza(int id)
		{
			return await _pizzaRepository.GetPizza(id);
		}

	}
}
