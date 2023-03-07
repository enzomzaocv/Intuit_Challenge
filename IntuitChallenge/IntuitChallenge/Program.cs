using Business.Implemetations;
using Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Context;
using Repository.Implementations;
using Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigin = "myAllowedOrigins";

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("CoreDbConnectionString");
builder.Services.AddDbContext<CoreDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerBusiness, CustomerBusiness>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: allowedOrigin,
		builder =>
		{
			builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyHeader();
		});
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(allowedOrigin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
