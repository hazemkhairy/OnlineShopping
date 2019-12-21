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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ItemService.svc or ItemService.svc.cs at the Solution Explorer and start debugging.
    public class ItemService : IItemService
    {
        ItemBLL itemBLL;
        public ItemService()
        {
            itemBLL = new ItemBLL();
        }
        public ResponseResult Add(ItemDTO item)
        {
            return itemBLL.Add(item);
        }

        public ResponseResult Delete(string itemId)
        {
            return itemBLL.Delete(int.Parse(itemId));
        }

        public ItemDTO GetItem(string id)
        {
            return itemBLL.GetItem(int.Parse(id));
        }

        public List<ItemDTO> GetItems(string categoryId)
        {
            return itemBLL.GetItems(int.Parse(categoryId));
        }
    }
}
