using System.Xml.Serialization;
using AutoMapper;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.CuisineTypes;
using RestaurantManagement_Shared.Dtos.Foods;
using RestaurantManagement_Shared.Dtos.MealTypes;
using RestaurantManagement_Shared.Dtos.RestaurantCuisineType;
using RestaurantManagement_Shared.Dtos.RestaurantReviews;
using RestaurantManagement_Shared.Dtos.Restaurants;

namespace RestaurantManagement_Shared.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //  Restaurant
            CreateMap<AddAndUpdateRestaurantDto, Restaurant>().ReverseMap();
            CreateMap<Restaurant, DetailsRestaurantDto>().ReverseMap();

            //CuisineType
            CreateMap<CuisineType, DetailsCuisineTypeDto>();
            CreateMap<AddAndEditCuisineTypeDto, CuisineType>();

            //RestaurantCuisineType
            CreateMap<RestaurantCuisineType, DetailsRestaurantCuisineTypeDto>()
            .ForMember(d => d.RestaurantName,
                opt => opt.MapFrom(s => s.Restaurant.Name))
            .ForMember(d => d.CuisineName,
                opt => opt.MapFrom(s => s.CuisineType.Name));

            CreateMap<AddAndEditRestaurantCuisineTypeDto, RestaurantCuisineType>();

            //RestaurantReview
            CreateMap<AddAndEditRestaurantReviewDto,RestaurantReview>();
            CreateMap<RestaurantReview, DetailsRestaurantReviewDto>()
                  .ForMember(r=>r.RestaurantName,
                          opt=>opt.MapFrom(src=>src.Restaurant.Name)).ReverseMap();

            //MealType
            CreateMap<AddAndEditMealTypeDto, MealType>();
            //MealType
            CreateMap<AddAndEditFoodDto, Food>();
            CreateMap<Food, DetailsFoodDto>();
        }
    }
}
