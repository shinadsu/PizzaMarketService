﻿using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;

namespace PizzaMarketService.Repositories.PizzaShopRepositories
{
	public class PromotionRepository : IPromotionInterface
	{
		public Task<Promotion> DELETE(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Promotion>> GET()
		{
			throw new NotImplementedException();
		}

		public Task<Promotion> GET(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Promotion> POST(Review review)
		{
			throw new NotImplementedException();
		}

		public Task<Promotion> PUTCH(Review reviewtoUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
