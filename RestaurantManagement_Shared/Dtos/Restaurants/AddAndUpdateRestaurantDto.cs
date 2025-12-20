namespace RestaurantManagement_Shared.Dtos.Restaurants
{
  public class AddAndUpdateRestaurantDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
        public int WorkingHours { get; set; }
        public TimeSpan StartingWork { get; set; }
        
    }
}
