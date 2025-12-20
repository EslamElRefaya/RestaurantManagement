namespace RestaurantManagement_Domain.Models
{
    public class Menu
    {
        public int MenuId { get; set; }

        public int MealTypeId { get; set; }
        public MealType MealType { get; set; } = default!;

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = default!;

       public ICollection<Food> Foods { get; set; } = new List<Food>();

    }
}
