﻿using OnlineShoppingBE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OnlineShoppingBE.Controllers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        ResponseResult Register(UserDTO user);

        [OperationContract]
        ResponseResult Login(UserDTO user);

        [OperationContract]
        bool isAdmin(string id);


    }
}
