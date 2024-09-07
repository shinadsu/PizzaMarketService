using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaMarketService.Controllers;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMarketUnitService
{
	[TestClass]
	public class PizzaUnit
	{	
		private Mock<IPizzaRepository>? _repositoryMock;
		private PizzaController? _controllerMock;

		[TestInitialize]
		public void SetUp() 
		{	
			_repositoryMock = new Mock<IPizzaRepository>();

			_repositoryMock.Setup(r => r.GetPizzas()).ReturnsAsync(new List<Pizza>
			{
				new Pizza { Id = 1, CategoryId = 1, Description = "ddddds", Name = "ssssss", },
				new Pizza { Id = 2, CategoryId = 2, Description = "dddddssss", Name = "ssssssddddd", }
			});

			_controllerMock = new PizzaController(_repositoryMock.Object);

		}

		[TestMethod]
		public async Task TestGetPizzasReturnsList()
		{
			var result = await _controllerMock?.GetPizzasAsync();

			Assert.IsNotNull(result, "Result should not be null.");

			Assert.IsTrue(result.Count > 0, "nice");
		}


		[TestCleanup]
		public void Cleanup()
		{

		}
	}
}
