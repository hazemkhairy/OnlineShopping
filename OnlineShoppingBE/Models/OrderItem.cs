using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShoppingBE.Models
{
    public class OrderItem
    {

        [Required]
        public Order Order { get; set; }

        [Required]
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]

        [Key, Column(Order = 1)]
        public int ItemID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}