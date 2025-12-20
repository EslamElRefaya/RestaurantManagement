namespace RestaurantManagement_Shared.Dtos.Restaurants
{
    public class DetailsRestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
        public TimeSpan StartingWork { get; set; }
        public int WorkingHours { get; set; }
        public bool IsOpenning { get; set; }
    }
}
