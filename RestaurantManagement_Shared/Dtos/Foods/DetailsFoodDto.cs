namespace RestaurantManagement_Shared.Dtos.Foods
{
    public class DetailsFoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string URL { get; set; } = string.Empty;
        public int MenuId { get; set; }
    }
}
