using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Products
{
    public class ProductIndexDTOs
    {
        public ProductCreateDTOs productCreateDTOs { get; set; }
        public List<ProductGetDTOs> productGetDTOs { get; set;}
        public ProductGetDTOs ProductGetDTOs { get; set;}
        public ProductUpdateDTOs productUpdateDTOs { get; set; }
    }
}
