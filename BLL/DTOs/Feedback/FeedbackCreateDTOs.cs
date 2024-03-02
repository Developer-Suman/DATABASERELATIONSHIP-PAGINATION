using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Feedback
{
    public class FeedbackCreateDTOs
    {
        [Required]
        public string FeedbackName { get; set; }
        [Required]
        public int ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
