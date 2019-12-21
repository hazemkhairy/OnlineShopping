using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingBE.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Descripition { get; set; }

        public string ImageURL { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int NumberOfSold { get; set; }
    }
}