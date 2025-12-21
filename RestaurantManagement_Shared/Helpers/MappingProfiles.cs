using AutoMapper;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.Restaurants;

namespace RestaurantManagement_Shared.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            // AddAndUpdateRestaurantDto <-> Restaurant
            CreateMap<AddAndUpdateRestaurantDto, Restaurant>().ReverseMap();

            // Restaurant -> DetailsRestaurantDto
            CreateMap<Restaurant, DetailsRestaurantDto>().ReverseMap();
                

        }
    }
}
