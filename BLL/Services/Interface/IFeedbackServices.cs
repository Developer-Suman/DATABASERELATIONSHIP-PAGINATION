using BLL.DTOs.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IFeedbackServices
    {
        Task<FeedbackGetDTOs> CreateFeedback(FeedbackCreateDTOs feedbackCreateDTOs);
        Task<List<FeedbackGetDTOs>> GetAllFeedbacks();
        Task<FeedbackGetDTOs> GetFeedbacksById(int FeedbackId);
        Task<FeedbackGetDTOs> UpdateFeedback(FeedbackUpdateDTOs feedbackUpdateDTOs);
        Task<bool> DeleteFeedback(int FeedbackId);

    }
}
