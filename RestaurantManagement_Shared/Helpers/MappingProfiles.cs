using AutoMapper;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.CuisineTypes;
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
        }
    }
}
