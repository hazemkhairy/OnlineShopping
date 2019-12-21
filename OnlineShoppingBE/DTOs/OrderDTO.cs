using OnlineShoppingBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingBE.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List <KeyValuePair<int,int>> products { get; set; }
        public PaymentTypeDTO paymentType { get; set; }
        public UserDTO user { get; set; } 
        public OrderDTO ()
        {
            products = new List<KeyValuePair<int, int>>();
        }
    }
}