namespace RestaurantManagement_Domain.Models
{
    public class RestaurantCuisineType
    {
        public int RestaurantCuisineTypeId { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = default!;

        public int CuisineTypeId { get; set; }
        public CuisineType CuisineType { get; set; } = default!;

    }
}
