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
	public class OrderController : ControllerBase
	{	
		private IOrderRepository _orderRepository;
		public OrderController(IOrderRepository orderRepository) 
		{
			_orderRepository = orderRepository;
		}

		[HttpGet]
		public async Task<List<Order>> Get()
		{
			try
			{
				return await _orderRepository.Get();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		[HttpGet("id:int")]
		public async Task<Order> Get(int id)
		{
			return await _orderRepository.GetWithid(id);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Order order)
		{
			if (order == null)
				return BadRequest("Order is null");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _orderRepository.post(order);
				return Ok(order); 
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
		public async Task<IActionResult> delete(int id)
		{
			if (id == 0)
				return BadRequest("id is not valid");

			try
			{
				await _orderRepository.delete(id);
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
