
using OnlineShoppingBE.DTOs;
using OnlineShoppingBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OnlineShoppingBE.BLL
{
    public class OrderBLL
    {
        public OrderBLL()
        {

        }

        private List<KeyValuePair<int, int>> getProducts(int orderID)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<OrderItem> products = _context.OrderItems.Include("Category").Where(i => i.OrderID == orderID).ToList();
                List<KeyValuePair<int, int>> user_products = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < products.Count; i++)
                {
                    user_products.Add(new KeyValuePair<int, int>(products[i].ItemID, products[i].Quantity));
                }
                return user_products;
            }

        }
        private OrderDTO convertToDTO(Order order)
        {
            return new OrderDTO()
            {
                Address = order.Address,
                City = order.City,
                Country = order.Country,
                FullName = order.ReciverFullName,
                Zip = order.ZIPCode,
                paymentType = new PaymentTypeDTO()
                {
                    ID = order.PaymentType.ID,
                    Name = order.PaymentType.Name
                },
                OrderID = order.ID,
                user = new UserDTO()
                {
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    Email = order.User.Email,
                    ID = order.User.ID,
                    Password = order.User.Password
                },
                products = getProducts(order.ID)
            };

        }
        public List<OrderDTO> GetAll(string userID)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {

                int id = int.Parse(userID);
                User user = _context.Users.FirstOrDefault(u => u.ID == id);

                List<OrderDTO> allOrders = new List<OrderDTO>();
                if (false)
                {
                    List<Order> orders = _context.Orders.Include("PaymentType").Include("User").ToList();
                    for (int i = 0; i < orders.Count; i++)
                    {
                        allOrders.Add(GetOrder(orders[i].ID.ToString()));
                    }

                }
                else
                {
                    List<Order> orders = _context.Orders.Include("PaymentType").Include("User").Where(o => o.UserID == id).ToList();
                    for (int i = 0; i < orders.Count; i++)
                    {
                        allOrders.Add(GetOrder(orders[i].ID.ToString()));
                    }
                }

                return allOrders;
            }
        }

        public OrderDTO GetOrder(string orderID)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Order order = _context.Orders.Include("PaymentType").Include("User").FirstOrDefault(o => o.ID == int.Parse(orderID));


                return convertToDTO(order);
            }
        }
        public ResponseResult PlaceOrder(OrderDTO order)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Order newOrder = new Order()
                {
                    ReciverFullName = order.FullName,
                    Address = order.Address,
                    ZIPCode = order.Zip,
                    Country = order.Country,
                    City = order.City,
                    PaymentTypeID = order.paymentType.ID,
                    UserID = order.user.ID
                };


                User user = _context.Users.FirstOrDefault(u => u.ID == newOrder.UserID);

                if (user == null)
                {
                    return new ResponseResult()
                    {
                        Message = "User Dosen't Exists",
                        StatusCode = 404
                    };
                }

                PaymentType Payment = _context.PaymentTypes.FirstOrDefault(p => p.ID == newOrder.PaymentTypeID);
                if (Payment == null)
                {
                    return new ResponseResult() { Message = "Paymen Doesn't Exist", StatusCode = 404 };
                }


                for (int i = 0; i < order.products.Count; i++)
                {
                    int itemId = order.products[i].Key;
                    Item temp = _context.Items.FirstOrDefault(it => it.ID == itemId);
                    if (temp == null)
                    {
                        return new ResponseResult()
                        {
                            Message = "Item with id = " + order.products[i].Key.ToString() + " not exists",
                            StatusCode = 404
                        };
                    }
                    newOrder.TotalCost += temp.Cost * order.products[i].Value;
                }

                _context.Orders.Add(newOrder);

                _context.SaveChanges();
                for (int i = 0; i < order.products.Count; i++)
                {
                    OrderItem orderitem = new OrderItem()
                    {
                        OrderID = newOrder.ID,
                        ItemID = order.products[i].Key,
                        Quantity = order.products[i].Value
                    };
                    _context.OrderItems.Add(orderitem);
                }

                _context.SaveChanges();
                return new ResponseResult() { Message = "Order Placed succesfully", StatusCode = 202 };
            }
        }
    }
}