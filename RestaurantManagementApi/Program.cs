using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Applicatin.Services.CuisineTypes;
using RestaurantManagement_Applicatin.Services.FoodReviews;
using RestaurantManagement_Applicatin.Services.Foods;
using RestaurantManagement_Applicatin.Services.MealTypes;
using RestaurantManagement_Applicatin.Services.RestaurantCuisineTypes;
using RestaurantManagement_Applicatin.Services.RestaurantReviews;
using RestaurantManagement_Applicatin.Services.Restaurants;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var defaultConnection = builder.Configuration.GetConnectionString("MyConnectionDbBySqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnection));
// ///////////////this P-->> 8 
// Add AutoMapper  ==>> You Must put MappingProfiles insted of Program
builder.Services.AddAutoMapper(typeof(MappingProfiles));

///////////////////// this P-->> 9
//////////////////// Add Repository & Services (Your Application)
// Restaurant-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<Restaurant>,RestaurantRepository>();
builder.Services.AddScoped<IRestaurantsService,RestaurantsService>();
// CuisineType-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<CuisineType>, CuisineTypRepository>();
builder.Services.AddScoped<ICuisineTypeServices, CuisineTypeServices>();
// RestaurantCuisineType-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<RestaurantCuisineType>, RestaurantCuisineTypeRepository>();
builder.Services.AddScoped<IRestaurantCuisineTypeServices, RestaurantCuisineTypeServices>();
// IRestaurantReview-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<RestaurantReview>, RestaurantReviewRepository>();
builder.Services.AddScoped<IRestaurantReviewService, RestaurantReviewService>();
// IRestaurantReview-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<MealType>, MealTypeRepository>();
builder.Services.AddScoped<IMealTypeServices, MealTypServices>();
// Food-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<Food>, FoodRepoistory>();
builder.Services.AddScoped<IFoodServices, FoodServices>();
// Food-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<FoodReview>, FoodReviewRepository>();
builder.Services.AddScoped<IFoodReviewServices, FoodReviewServices>();

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
