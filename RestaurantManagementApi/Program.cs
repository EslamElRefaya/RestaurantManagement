using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Applicatin.Services.Restaurants;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var defaultConnection = builder.Configuration.GetConnectionString("MyConnectionDbBySqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnection));

///////////////////// this P-->> 9
//////////////////// Add Repository & Services (Your Application)
// Restaurant-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<Restaurant>,RestaurantRepository>();
builder.Services.AddScoped<IRestaurantsService,RestaurantsService>();

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
