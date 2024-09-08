using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaMarketService.Controllers;
using PizzaMarketService.Models;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMarketUnitService
{
	[TestClass]
	public class PizzaUnit
	{
		private Mock<IPizzaRepository>? _repositoryMock;
		private PizzaController? _controller;

		[TestInitialize]
		public void SetUp()
		{
			_repositoryMock = new Mock<IPizzaRepository>();

			
			_repositoryMock.Setup(r => r.GetPizza(It.IsAny<int>())).ReturnsAsync(new Pizza
			{
				Id = 1,
				CategoryId = 1,
				Description = "ddddds",
				Name = "ssssss"
			});

			
			_repositoryMock.Setup(r => r.GetPizzas()).ReturnsAsync(new List<Pizza>
			{
				new Pizza { Id = 1, CategoryId = 1, Description = "Description 1", Name = "Pizza 1" },
				new Pizza { Id = 2, CategoryId = 2, Description = "Description 2", Name = "Pizza 2" }
			});

			_controller = new PizzaController(_repositoryMock.Object);

			
		}

		[TestMethod]
		public async Task TestGetPizzasReturnsList()
		{
			var result = await _controller.GetPizzasAsync();

			Assert.IsNotNull(result, "Result should not be null.");
			Assert.IsTrue(result.Count > 0, "Result should contain pizzas.");
		}

		[DataRow(1)]
		[DataTestMethod]
		public async Task TestGetPizzaFromId(int id)
		{
			var result = await _controller.GetPizza(id);

			Assert.IsNotNull(result, "Result should not be null.");
			Assert.AreEqual(id, result.Id, "Returned pizza ID should match the requested ID.");
		}

		[DataRow(1)]
		[DataTestMethod]
		public async Task DeletePizza(int id)
		{
			if (id == 0)
				throw new ArgumentException(nameof(id));

			try
			{
				await _controller.DeletePizza(id);
				
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		
		[TestMethod]
		public async Task CreatePizza()
		{

			var pizza = new Pizza
			{
				CategoryId = 1,
				Description = "Marinara started as a pizza for… well, sailors and fishermen.",
				Name = "Marinara"
			};

			try
			{
				await _controller.AddPizzaAsync(pizza);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}

		}

		[TestCleanup]
		public void Cleanup()
		{
			
		}

		
	}
}
