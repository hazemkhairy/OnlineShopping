using OnlineShoppingBE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OnlineShoppingBE.Controllers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemService" in both code and config file together.
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        ResponseResult Add(ItemDTO item);
        [OperationContract]
        ItemDTO GetItem(string id);
        [OperationContract]
        List<ItemDTO> GetItems(string categoryId);
        [OperationContract]
        ResponseResult Delete(string itemId);
    }
}
