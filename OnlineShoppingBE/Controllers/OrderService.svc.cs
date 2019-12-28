using OnlineShoppingBE.BLL;
using OnlineShoppingBE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OnlineShoppingBE.Controllers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderService.svc or OrderService.svc.cs at the Solution Explorer and start debugging.
    public class OrderService : IOrderService
    {
        public OrderBLL OrderBLL;
        public OrderService()
        {
            OrderBLL = new OrderBLL();
        }
        public ResponseResult PlaceOrder(OrderDTO order)
        {
            return OrderBLL.PlaceOrder(order);
        }
        public OrderDTO GetOrder(string orderID)
        {

            return OrderBLL.GetOrder(orderID);
        }
        public List<OrderDTO> GetAll(string userID)
        {
            return OrderBLL.GetAll(userID);
        }

    }
}
