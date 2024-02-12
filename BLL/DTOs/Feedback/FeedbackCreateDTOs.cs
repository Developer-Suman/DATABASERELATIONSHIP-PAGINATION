﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Feedback
{
    public class FeedbackCreateDTOs
    {
        public string FeedbackName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
