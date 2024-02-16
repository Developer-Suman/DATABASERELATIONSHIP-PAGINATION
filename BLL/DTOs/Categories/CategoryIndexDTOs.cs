using BLL.DTOs.Category;
using BLL.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Categories
{
    public class CategoryIndexDTOs
    {
        public CategoryUpdateDTOs CategoryUpdateDTOs { get; set; }
        public CategoryCreateDTOs CategoryCreateDTOs { get; set; }
       
        public List<CategoryGetDTOs> CategoryListDTOs { get; set; }

        public List<ProductGetDTOs> ProductGetAllDTOs { get; set; }
      

      
    }
}
