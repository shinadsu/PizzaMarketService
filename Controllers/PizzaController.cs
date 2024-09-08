﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using PizzaMarketService.Repositories.PizzaShopRepositories;
using System.Data.Common;

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
		public async Task<IActionResult> AddPizzaAsync(Pizza pizza)
		{
			if (pizza == null)
				return BadRequest("Order is null");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _pizzaRepository.AddAsync(pizza);
				return Ok(pizza);
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
				await _pizzaRepository.DeleteAsync(id);
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
