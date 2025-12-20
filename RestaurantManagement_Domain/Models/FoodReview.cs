using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement_Domain.Models
{
  public class FoodReview
    {
        public int FoodReviewId { get; set; }
        public string Description { get; set; }=string.Empty;

        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
