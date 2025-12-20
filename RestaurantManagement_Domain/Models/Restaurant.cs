using System;
using System.ComponentModel.DataAnnotations;
namespace RestaurantManagement_Domain.Models
{
    public class Restaurant: BaseEntity
    {
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime StartingWork { get; set; }
        public int WorkingHours { get; set; }
        public bool IsOpenning { get; set; }

        public ICollection<RestaurantCuisineType> RestaurantCuisineType { get; set; }=new List<RestaurantCuisineType>();
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<RestaurantReview> RestaurantReviews { get; set; } = new List<RestaurantReview>();

    }
}
