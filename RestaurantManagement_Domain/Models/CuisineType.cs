namespace RestaurantManagement_Domain.Models
{
    public class CuisineType:BaseEntity
    {
        public ICollection<RestaurantCuisineType> RestaurantCuisineType { get; set; } = new List<RestaurantCuisineType>();
    }
}
