namespace RestaurantManagement_Shared.Dtos.RestaurantCuisineType
{
   public class DetailsRestaurantCuisineTypeDto
    {
        public int RestaurantCuisineTypeId { get; set; }

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; } = default!;

        public int CuisineTypeId { get; set; }
        public string CuisineName { get; set; } = default!;

    }
}
