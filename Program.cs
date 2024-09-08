using PizzaMarketService.Data;
using PizzaMarketService.Repositories.IPizzaShopRepository;
using PizzaMarketService.Repositories.PizzaShopRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ����������� DbContext � ����������� �� builder.Build()
builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaShopContext"), sqlServerOptionsAction =>
	{
		sqlServerOptionsAction.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
	}));

// scoped interface & clss 
builder.Services.AddScoped<IFastfoodRepository, FastfoodRepositiry>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepositories, UserRepository>();

// Add controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
	swagger.EnableAnnotations();
	swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PizzaShopAPI", Version = "V1"});
});

var app = builder.Build(); 

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
