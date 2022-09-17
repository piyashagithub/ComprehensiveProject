using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceriesStore.Models
{
    public class GroceryModel
    {
        [Key]
        public int GroceryId { get; set; }
        [Required]
        public string GroceryName { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
