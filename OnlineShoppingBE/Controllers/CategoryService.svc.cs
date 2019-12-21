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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CategoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CategoryService.svc or CategoryService.svc.cs at the Solution Explorer and start debugging.
    public class CategoryService : ICategoryService
    {
        private CategoryBLL categoryBLL;
        public CategoryService()
        {
            categoryBLL = new CategoryBLL();
        }
        public List<CategoryDTO> GetAll()
        {
            return categoryBLL.GetAll();
        }
        public ResponseResult Add(CategoryDTO category)
        {
            return categoryBLL.Add(category);
        }
    }
}
