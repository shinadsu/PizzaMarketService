using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using PizzaMarketService.Repositories.PizzaShopRepositories;
using System.Data.Common;

namespace PizzaMarketService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FastfoodController : ControllerBase
	{
		private IFastfoodRepository _fastfoodRepository;
		public FastfoodController(IFastfoodRepository fastfoodRepository)
		{
			_fastfoodRepository = fastfoodRepository;
		}

		[HttpGet(Name = "GetPizzasAsync")]
		public async Task<List<Fastfood>> GetFastfoodsAsync()
		{
			return await _fastfoodRepository.GetFastfoods();
		}


		[HttpGet("id:int")]
		public async Task<Fastfood> GetPizza(int id)
		{
			return await _fastfoodRepository.GetFastfood(id);
		}


		[HttpPost(Name = "AddPizzaAsync")]
		public async Task<IActionResult> AddPizzaAsync(Fastfood fastfood)
		{
			if (fastfood == null)
				return BadRequest("Order is null");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _fastfoodRepository.AddAsync(fastfood);
				return Ok(fastfood);
			}
			catch (DbUpdateException dbEx)
			{
				return StatusCode(500, $"Database update error: {dbEx.InnerException?.Message ?? dbEx.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}


		[HttpDelete("id:int")]
		[IgnoreAntiforgeryToken]
		public async Task<IActionResult> DeletePizza(int id)
		{
			if (id == 0)
				return BadRequest("id is not valid");

			try
			{
				await _fastfoodRepository.DeleteAsync(id);
				return Ok("the order was deleted");
			}
			catch (DbException DBex)
			{
				return StatusCode(500, $"Database delete error: {DBex.InnerException?.Message ?? DBex.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
