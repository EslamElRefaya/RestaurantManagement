using AutoMapper;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.CuisineTypes;
using RestaurantManagement_Shared.Dtos.FoodReviews;
using RestaurantManagement_Shared.Dtos.Foods;
using RestaurantManagement_Shared.Dtos.MealTypes;
using RestaurantManagement_Shared.Dtos.OrderItems;
using RestaurantManagement_Shared.Dtos.Orders;
using RestaurantManagement_Shared.Dtos.RestaurantCuisineType;
using RestaurantManagement_Shared.Dtos.RestaurantReviews;
using RestaurantManagement_Shared.Dtos.Restaurants;

namespace RestaurantManagement_Shared.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Restaurant
            CreateMap<AddAndUpdateRestaurantDto, Restaurant>().ReverseMap();
            CreateMap<Restaurant, DetailsRestaurantDto>().ReverseMap();
            #endregion

            #region CuisineType
            CreateMap<CuisineType, DetailsCuisineTypeDto>();
            CreateMap<AddAndEditCuisineTypeDto, CuisineType>();
            #endregion

            #region RestaurantCuisineType
            CreateMap<RestaurantCuisineType, DetailsRestaurantCuisineTypeDto>()
                .ForMember(d => d.RestaurantName,
                    opt => opt.MapFrom(s => s.Restaurant.Name))
                .ForMember(d => d.CuisineName,
                    opt => opt.MapFrom(s => s.CuisineType.Name));

            CreateMap<AddAndEditRestaurantCuisineTypeDto, RestaurantCuisineType>();

            #endregion

            //RestaurantReview
            CreateMap<AddAndEditRestaurantReviewDto, RestaurantReview>();
            CreateMap<RestaurantReview, DetailsRestaurantReviewDto>()
                  .ForMember(r => r.RestaurantName,
                          opt => opt.MapFrom(src => src.Restaurant.Name)).ReverseMap();

            //MealType
            CreateMap<AddAndEditMealTypeDto, MealType>();

            //Food
            CreateMap<AddAndEditFoodDto, Food>()
                .ForMember(dest => dest.URL, opt => opt.Ignore());
            CreateMap<Food, DetailsFoodDto>();

            //FoodReview
            CreateMap<AddAndEditFoodReviewDto, FoodReview>();
            CreateMap<FoodReview, DetailsFoodReviewDto>()
                                .ForMember(fd => fd.FoodName,
                                    opt => opt.MapFrom(src => src.Food.Name));

            //OrderItem
            CreateMap<AddAndEditOrderItemDto, OrderItem>();
            CreateMap<OrderItem, DetailsOrderItemDto>()
                                .ForMember(oi => oi.FoodName,
                                     opt => opt.MapFrom(src => src.Food.Name))
                                .ForMember(dest => dest.PricePerUnit,
                                     opt => opt.MapFrom(src => src.Price));
            
            //Order
            CreateMap<AddOrderDto, Order>();
            CreateMap<EditOrderDto, Order>();
            CreateMap<Order, DetailsOrderDto>()
                .ForMember(dest => dest.RestaurantName,
                           opt => opt.MapFrom(src => src.Restaurant.Name))
                .ForMember(dest=>dest.UserFullName,
                           opt =>opt.MapFrom(src=>$"{src.ApplicationUser.FristName} {src.ApplicationUser.LastName}"))
                .ForMember(dest => dest.Items,
                           opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.TotalPrice,
                           opt => opt.MapFrom(src =>
                               src.OrderItems.Sum(i => i.Price * i.Quantity)));
        }
    }
}
