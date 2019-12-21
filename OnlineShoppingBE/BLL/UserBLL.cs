using OnlineShoppingBE.DTOs;
using OnlineShoppingBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OnlineShoppingBE.BLL
{
    public class UserBLL
    {
        public UserBLL()
        {
        }

        public ResponseResult Register(UserDTO user)
        {
            using (var _context = new ApplicationDbContext())
            {
                User user1 = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (user1 != null)
                {
                    return new ResponseResult()
                    { Message = "Email Already Exists", StatusCode = 409 };
                }
                user1 = new User()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    IsAdmin = false
                };

                _context.Users.Add(user1);
                _context.SaveChanges();
                user.ID = user1.ID;
                return new ResponseResult()
                { Message = "User Added Succesfully", StatusCode = 202 };

            }
        }
        public ResponseResult Login(UserDTO user)
        {
            using (var _context = new ApplicationDbContext())
            {
                User user1 = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (user1 == null)
                {

                    return new ResponseResult()
                    { Message = "Invalid UserName or Password", StatusCode = 404 };
                }



                return new ResponseResult()
                { Message = "Login Succefully", StatusCode = 200 };
            }
        }
        public bool isAdmin(int id)
        {
            using (var _context = new ApplicationDbContext())
            {
                User user = _context.Users.FirstOrDefault(i => i.ID == id);
                if (user != null && user.IsAdmin)
                {
                    return true;
                }
                return false;
            }
        }

    }
}