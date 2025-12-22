namespace RestaurantManagement_Domain.Models
{
    public class MealType : BaseEntity
    {
        public ICollection<Menu> Menus = new List<Menu>();
    }
}
