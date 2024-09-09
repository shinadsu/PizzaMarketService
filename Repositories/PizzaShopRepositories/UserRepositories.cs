using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Data;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using System.Web.Http;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class UserRepositories : IUserInterface
	{
		private DataContext _dataContext;
		public UserRepositories(DataContext dataContext) 
		{
			_dataContext = dataContext;
		}
		public async Task DELETE(int id)
		{
			if (id == 0)
				throw new ArgumentException(nameof(id));

			var deleteUser = await _dataContext.users.FirstOrDefaultAsync(c => c.Id == id);

			_dataContext.users.Remove(deleteUser);
			await _dataContext.SaveChangesAsync();
		}

		public async Task<List<User>> GET()
		{
			return await _dataContext.users.AsNoTracking().ToListAsync();
		}

		public async Task<User> GET(int id)
		{
			if (id == 0)
				throw new ArgumentException(nameof(id));

			return await _dataContext.users.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task POST(User user)
		{
			if (user == null) throw new ArgumentNullException(nameof(user));

			await _dataContext.users.AddAsync(user);
			await _dataContext.SaveChangesAsync();
		}

		
		public async Task PUTCH(User usertoUpdate)
		{
			if (usertoUpdate == null)
				throw new ArgumentNullException(nameof(usertoUpdate));

			var oldUser = await _dataContext.users.FirstOrDefaultAsync(c => c.Id == usertoUpdate.Id);

			if (oldUser == null || usertoUpdate == null)
				throw new ArgumentNullException("one of the parametrs is null");

			oldUser.Name = usertoUpdate.Name;
			oldUser.Email = usertoUpdate.Email;
			oldUser.PasswordHash = usertoUpdate.PasswordHash;
			oldUser.Role = usertoUpdate.Role;
			oldUser.Address = usertoUpdate.Address;
			oldUser.PhoneNumber = usertoUpdate.PhoneNumber;

			if (oldUser == null)
				throw new ArgumentNullException("user cannot be null");

			_dataContext.users.Update(oldUser);
			await _dataContext.SaveChangesAsync();
		}
	}
}
