using AutoMapper;
using RestaurantManagement_Domain.Models;
using RestaurantManagement_Shared.Dtos.Restaurants;

namespace RestaurantManagement_Shared.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Restaurant Mappings
            //CreateMap<AddAndUpdateRestaurantDto, Restaurant>().ReverseMap();
            CreateMap<Restaurant, DetailsRestaurantDto>().ReverseMap();
            



        }
    }
}
