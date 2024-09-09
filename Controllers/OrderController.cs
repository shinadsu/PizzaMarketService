using Microsoft.AspNetCore.Mvc;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using System.Data.Common;

namespace PizzaMarketService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{	
		private IOrderInterface _orderInterface;
		public OrderController(IOrderInterface orderInterface) 
		{
			_orderInterface = orderInterface;
		}


		[HttpGet]
		public async Task<List<Order>> GetOrders()
		{
			return await _orderInterface.GET();
		}


		[HttpGet( "{id:int}" )]
		public async Task<Order> GetProducts(int id)
		{
			if ( id == 0 )
				throw new ArgumentException( nameof( id ) );

			try
			{
				return await _orderInterface.GET( id );
			}
			catch ( Exception ex )
			{

				throw new Exception( ex.Message );
			}
		}


		[HttpPost]
		public async Task<IActionResult> PostProduct(Order order)
		{
			if ( order == null )
				return BadRequest( "User cannot be null" );

			if ( !ModelState.IsValid )
				return BadRequest( "data is not valid" );

			try
			{
				await _orderInterface.POST( order );
				return Ok();
			}
			catch ( DbException dbEx )
			{
				return StatusCode( 500, $"Invalid operationd to database: {dbEx.InnerException?.Message ?? dbEx.Message}" );
			}
			catch ( Exception ex )
			{
				return StatusCode( 500, $"internal server error: {ex.Message}" );
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			if ( id == null || id == 0 )
				return BadRequest( "User cannot be null" );

			try
			{
				await _orderInterface.DELETE( id );
				return Ok();
			}
			catch ( DbException dbEx )
			{
				return StatusCode( 500, $"Invalid operationd to database: {dbEx.InnerException?.Message ?? dbEx.Message}" );
			}
			catch ( Exception ex )
			{
				return StatusCode( 500, $"internal server error: {ex.Message}" );
			}
		}

		[HttpPatch]
		public async Task<IActionResult> updateOrder(Order updatedOrder, int id)
		{
			var oldestUser = await _orderInterface.GET(id);

			if ( _orderInterface == null || oldestUser == null )
				return BadRequest( "one of the parametrs is null" );

			if ( !ModelState.IsValid )
				return BadRequest( "bad request" );

			try
			{
				await _orderInterface.PUTCH( updatedOrder );
				return Ok();
			}
			catch ( DbException dbEx )
			{
				return StatusCode( 500, $"internal databse error: {dbEx.InnerException?.Message ?? dbEx.Message}" );
			}
			catch ( Exception ex )
			{
				return StatusCode( 500, $"internal server error: {ex.InnerException?.Message ?? ex.Message}" );
			}
		}

	}
}
