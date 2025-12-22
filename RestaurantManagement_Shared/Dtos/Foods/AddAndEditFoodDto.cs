namespace RestaurantManagement_Shared.Dtos.Foods
{
    public class AddAndEditFoodDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string URL { get; set; } = string.Empty;
        public int MenuId { get; set; }
    }
}
