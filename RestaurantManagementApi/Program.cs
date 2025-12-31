using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement_Applicatin.Repository;
using RestaurantManagement_Applicatin.Services.Account;
using RestaurantManagement_Applicatin.Services.CuisineTypes;
using RestaurantManagement_Applicatin.Services.FoodReviews;
using RestaurantManagement_Applicatin.Services.Foods;
using RestaurantManagement_Applicatin.Services.MealTypes;
using RestaurantManagement_Applicatin.Services.OrderItems;
using RestaurantManagement_Applicatin.Services.Orders;
using RestaurantManagement_Applicatin.Services.Payments;
using RestaurantManagement_Applicatin.Services.RestaurantCuisineTypes;
using RestaurantManagement_Applicatin.Services.RestaurantReviews;
using RestaurantManagement_Applicatin.Services.Restaurants;
using RestaurantManagement_Data;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Helpers;
// this P-->> 1
var builder = WebApplication.CreateBuilder(args);

// this P-->> 2
// Add Framework Services.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// this P-->> 3
//Add Configuration & Options

// this P-->> 4
//Add connection string or Add 'DbContext'
var defaultConnection = builder.Configuration.GetConnectionString("MyConnectionDbBySqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnection));

// this P-->> 5
//add inject userManager and roleManager identity to application
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>();


// this P-->> 6
// this add Custom JWT Authentication
builder.Services.AddJWTAuthentication(builder.Configuration);
builder.Services.AddSwaggerGenAuthentication();
// this P-->> 7
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

// ///////////////this P-->> 8 
// Add AutoMapper  ==>> You Must put MappingProfiles insted of Program
builder.Services.AddAutoMapper(typeof(MappingProfiles));


/////////////// this P-->> 9
#region Add Repository & Services (Your Application)
// Restaurant-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<Restaurant>, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantsService, RestaurantsService>();
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
// Order-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
// Payment-- >> Repo & Srev
//builder.Services.AddScoped<IRestaurantManagementRepository<P>, OrderRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
// OrderItem-->> Repo & Srev
builder.Services.AddScoped<IRestaurantManagementRepository<OrderItem>, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
// Account-->> Repo & Srev
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

#endregion

//////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
//////////////////////////////////////////////////////////////////////////////////////////////

// this P-->> 1
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// this P-->> 2
//HTTPS redirection
app.UseHttpsRedirection();

// this P-->> 3
//CORS
app.UseCors("AllowAll");
// this P-->> 4
app.UseAuthentication();

// this P-->> 5
app.UseAuthorization();

// this P-->> 6
app.MapControllers();

// this P-->> 7
app.Run();