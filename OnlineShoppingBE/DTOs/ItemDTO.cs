
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingBE.DTOs
{
    public class ItemDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public string Descripition { get; set; }

        public string ImageURL { get; set; }

        public CategoryDTO Category { get; set; }

        public int CategoryID { get; set; }
    }
}