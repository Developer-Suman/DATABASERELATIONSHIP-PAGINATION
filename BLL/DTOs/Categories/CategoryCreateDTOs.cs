using BLL.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Category
{
    public class CategoryCreateDTOs
    {
        public string CategoryName { get; set; }
        public IList<ProductGetDTOs> Products { get; set; }
    }
}
