using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement_Domain.Models
{
   public class RestaurantReview
    {
        public int RestaurantReviewId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = default!;
    }
}
