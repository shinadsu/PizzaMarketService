using PizzaMarketService.Data;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using PizzaMarketService.Repositories.PizzaShopRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Регистрация DbContext и репозитория до builder.Build()
builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaShopContext"), sqlServerOptionsAction =>
	{
		sqlServerOptionsAction.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
	}));

builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();


// Add controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // builder.Build() должен быть после всех добавлений в коллекцию сервисов

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
