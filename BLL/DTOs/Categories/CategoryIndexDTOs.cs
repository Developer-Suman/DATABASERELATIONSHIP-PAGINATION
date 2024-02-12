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
        public CategoryDeleteDTOs CategoryDeleteDTOSs { get; set; }
        public CategoryUpdateDTOs CategoryUpdateDTOs { get; set; }
        public CategoryCreateDTOs CategoryCreateDTOs { get; set; }
        public CategoryGetAllDTOs CategoryGetAllDTOs { get; set; }
        public List<CategoryGetAllDTOs> CategoryListDTOs { get; set; }

        public List<ProductGetDTOs> ProductGetAllDTOs { get; set; }
      
        public CategoryGetByIdDTOs CategoryGetByIdDTOs { get; set; }
      
    }
}
