using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement_Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
    }
}
