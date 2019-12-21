using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingBE.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(60)]
        public string ReciverFullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(10)]
        public string ZIPCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public int PaymentTypeID { get; set; }
        [Required]
        public double TotalCost { get; set; }

        [Required]
        public User User { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}