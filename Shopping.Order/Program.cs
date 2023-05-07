using Microsoft.EntityFrameworkCore;
using Shopping.Order.MessageConsumer;
using Shopping.Order.Models.Context;
using Shopping.Order.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];

builder.Services.AddDbContext<MySqlContext>(options => options.
    UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 5))));

var builderContext = new DbContextOptionsBuilder<MySqlContext>();
builderContext.UseMySql(connection,
    new MySqlServerVersion(new Version(8, 0, 5))
);

builder.Services.AddSingleton(new OrderRepository(builderContext.Options));

builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
