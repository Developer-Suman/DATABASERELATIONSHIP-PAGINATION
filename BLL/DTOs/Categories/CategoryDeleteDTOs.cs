using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Category
{
    public class CategoryDeleteDTOs
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<ProductDTOs> Products { get; set; }
    }
}
