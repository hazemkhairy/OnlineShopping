using OnlineShoppingBE.DTOs;
using OnlineShoppingBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OnlineShoppingBE.BLL
{
    public class CategoryBLL
    {
        public CategoryBLL()
        {
        }
        public List<CategoryDTO> GetAll()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {

                List<Category> categories = _context.Categories.ToList();
                List<CategoryDTO> categoriesfinal = new List<CategoryDTO>();
                for (int i = 0; i < categories.Count; i++)
                {
                    categoriesfinal.
                        Add(new CategoryDTO() { Name = categories[i].Name, ID = categories[i].ID });
                }
                return categoriesfinal;
            }

        }
        public ResponseResult Add(CategoryDTO category)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Category newcategory = new Category() { Name = category.Name };
                if (_context.Categories.FirstOrDefault(c => c.Name == newcategory.Name) != null)
                {
                    return new ResponseResult()
                    { Message = "Category Already Exists", StatusCode = 409 };

                }
                _context.Categories.Add(newcategory);
                _context.SaveChanges();
                return new ResponseResult()
                { Message = "Category Added Succefully", StatusCode = 202 };
            }
        }
    }
}