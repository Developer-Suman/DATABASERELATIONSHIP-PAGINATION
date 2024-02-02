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
        public ProductDeleteDTOs productDeleteDTOs { get; set; }
        public List<ProductGetAllDTOs> productGetAllDTOs { get; set;}
        public ProductGetByIdDTOs productGetByIdDTOs { get; set;}
        public ProductUpdateDTOs productUpdateDTOs { get; set; }
    }
}
