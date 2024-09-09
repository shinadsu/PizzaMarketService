using Microsoft.AspNetCore.Mvc;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using System.Data.Common;

namespace PizzaMarketService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{	
		private IUserInterface _userInterface;
		public UserController(IUserInterface userInterface) 
		{
			_userInterface = userInterface;
		}	

		[HttpGet]
		public async Task<List<User>> GetUsers()
		{
			return await _userInterface.GET();
		}

		[HttpGet("{id:int}")]
		public async Task<User> GetUser(int id)
		{
			if (id == 0)
				throw new ArgumentException(nameof(id));

			try
			{
				return await _userInterface.GET(id);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> PostUser(User user)
		{
			if (user == null)
				return BadRequest("User cannot be null");

			if (!ModelState.IsValid)
				return BadRequest("data is not valid");

			try
			{
				await _userInterface.POST(user);
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

		[HttpDelete]
		public async Task<IActionResult> DeleteUser(int id)
		{
			if (id == null || id == 0)
				return BadRequest("User cannot be null");

			try
			{
				await _userInterface.DELETE(id);
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
		public async Task<IActionResult> UpdateUser(User updateUser, int id)
		{
			var oldUser = await _userInterface.GET(id);

			if (oldUser == null || updateUser == null)
				throw new ArgumentNullException("one of parametrs caanot be null");

			if (!ModelState.IsValid)
				return BadRequest("model is incorrect");

			try
			{
				await _userInterface.PUTCH(updateUser);
				return Ok();
			}
			catch (DbException dbEx)
			{
				return StatusCode(500, $"internal databse error: {dbEx.InnerException?.Message ?? dbEx.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"internal server error: {ex.Message}");
			}
		}
	}
}
