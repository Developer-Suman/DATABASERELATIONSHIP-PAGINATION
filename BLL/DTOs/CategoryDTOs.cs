using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryDTOs
    {
        public int CategoryId { get; set; }
        public string CategoryName { get;set; }
        public ICollection<ProductDTOs> Products { get; set; }
    }
}
