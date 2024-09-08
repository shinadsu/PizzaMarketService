using Microsoft.EntityFrameworkCore;
using PizzaMarketService.Data;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class UserRepository : IUserRepositories
	{	
		private DataContext _dataContext;
		public UserRepository(DataContext dataContext) 
		{
			_dataContext = dataContext;
		}
		public async Task Delete(int id)
		{
			if (id == 0) throw new ArgumentException(nameof(id), "the selected id is incorrect");

			var usertoDelete = await _dataContext.users.FirstOrDefaultAsync(x => x.Id == id);

			_dataContext.users.Remove(usertoDelete);
			await _dataContext.SaveChangesAsync();
		}

		public async Task<List<User>> GetAll()
		{
			return await _dataContext.users.AsNoTracking().ToListAsync();	
		}

		public async Task<User> GetById(int id)
		{
			if (id == 0) throw new ArgumentException(nameof(id), "the selected id is incorrect");

			return await _dataContext.users.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task Post(User user)
		{
			if (user == null) throw new ArgumentNullException(nameof(user));

			await _dataContext.AddAsync(user);
			await _dataContext.SaveChangesAsync();
		}
	}
}
