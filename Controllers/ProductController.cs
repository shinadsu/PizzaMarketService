using Microsoft.AspNetCore.Mvc;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using System.Data.Common;

namespace PizzaMarketService.Controllers
{
	[ApiController]
	[Route( "api/[controller]" )]
	public class ProductController : ControllerBase
	{
		private IProductInterface _productInterface;

		public ProductController(IProductInterface productInterface)
		{
			_productInterface = productInterface;
		}


		[HttpGet]
		public async Task<List<Product>> GetProduct()
		{
			return await _productInterface.GET();
		}


		[HttpGet( "{id:int}" )]
		public async Task<Product> GetProducts(int id)
		{
			if ( id == 0 )
				throw new ArgumentException( nameof( id ) );

			try
			{
				return await _productInterface.GET( id );
			}
			catch ( Exception ex )
			{

				throw new Exception( ex.Message );
			}
		}


		[HttpPost]
		public async Task<IActionResult> PostProduct(Product product)
		{
			if ( product == null )
				return BadRequest( "User cannot be null" );

			if ( !ModelState.IsValid )
				return BadRequest( "data is not valid" );

			try
			{
				await _productInterface.POST( product );
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
			if (id == null || id == 0)
				return BadRequest("User cannot be null");

			try
			{
				await _productInterface.DELETE(id);
				return Ok();
			}
			catch (DbException dbEx)
			{
				return StatusCode(500, $"Invalid operationd to database: {dbEx.InnerException?.Message ?? dbEx.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"internal server error: {ex.Message}");
			}
		}


		[HttpPatch]
		public async Task<IActionResult> updateProduct(Product updatedProduct, int id)
		{
			var oldestUser = await _productInterface.GET(id);

			if (updatedProduct == null || oldestUser == null)
				return BadRequest("one of the parametrs is null");

			if (!ModelState.IsValid)
				return BadRequest("bad request");

			try
			{
				await _productInterface.PUTCH(updatedProduct);
				return Ok();
			}
			catch (DbException dbEx)
			{
				return StatusCode(500, $"internal databse error: {dbEx.InnerException?.Message ?? dbEx.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode( 500, $"internal server error: {ex.InnerException?.Message ?? ex.Message}" );
			}
		}
	}
}
