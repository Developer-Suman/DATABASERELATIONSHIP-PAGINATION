using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Feedback
{
    public class FeedbackIndexDTOs
    {
        public FeedbackCreateDTOs FeedbackCreateDTOs { get; set; }
        public List<FeedbackGetDTOs> FeedbackListDTOs { get; set; }
        public FeedbackGetDTOs FeedbackGetDTOs { get;set; }
        public FeedbackUpdateDTOs FeedbackUpdateDTOs { get; set;}
    }
}
