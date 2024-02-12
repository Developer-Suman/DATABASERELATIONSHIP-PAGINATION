using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string FeedbackName { get; set; }
       
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
