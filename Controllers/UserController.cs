using Microsoft.AspNetCore.Mvc;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using Swashbuckle.AspNetCore.Annotations;
using System.Data.Common;

namespace PizzaMarketService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private IUserRepositories _userRepositories;
		public UserController(IUserRepositories userRepositories) 
		{ 
			_userRepositories = userRepositories;
		}

		
		[HttpGet]
		public async Task<List<User>> getUsers()
		{
			return await _userRepositories.GetAll();
		}

		[HttpGet("id:int")]
		public async Task<User> getUser(int id)
		{
			if (id == 0) throw new ArgumentException("id caanot be 0");

			try
			{
				return await _userRepositories.GetById(id);
			}
			catch (DbException ex)
			{
				throw new Exception($"invalid request: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> postUser(User user)
		{
			if (user == null) 
				return BadRequest("user cannot be null");

			if (!ModelState.IsValid)
				return BadRequest("not all params is valid");

			try
			{
				await _userRepositories.Post(user);
				return Ok(user);
			}
			catch (DbException ex)
			{
				return StatusCode(500, $"invalid operation to database: {ex.InnerException?.Message ?? ex.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"internal server error: {ex.Message}");
			}

			
		}

		[SwaggerOperation("Adds a new pet using the properties supplied, returns a GUID reference for the pet created.")]
		[HttpDelete("id:int")]
		public async Task<IActionResult> delelteUser(int id)
		{
			if (id == 0)
				return BadRequest("id caanot be 0");

			try
			{
				await _userRepositories.Delete(id);
				return Ok("user is deleted");
			}
			catch (DbException ex)
			{
				return StatusCode(500, $"invalid operation to database: {ex.InnerException?.Message ?? ex.Message}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"internal server error: {ex.Message}");
			}
		}

	}
}
