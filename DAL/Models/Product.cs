using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

    }
}
