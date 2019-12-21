using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingBE.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}