using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceriesStore.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel user { get; set; }

        public int? GroceryId { get; set; }
        [ForeignKey("GroceryId")]
        public virtual GroceryModel grocery { get; set; }
    }
}
