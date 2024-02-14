using BLL.DTOs.Feedback;
using BLL.DTOs.Products;
using BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackServices _feedbackServices;
        private readonly IProductServices _productServices;

        public FeedbackController(IFeedbackServices feedbackServices, IProductServices productServices)
        {
            _feedbackServices = feedbackServices;

            _productServices = productServices;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeedbacks()
        {
            IEnumerable<ProductGetDTOs> product = await _productServices.GetAllProduct();
            ViewBag.Feedbacks = new SelectList(product, "ProductId", "ProductName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateFeedbacks(FeedbackCreateDTOs feedbackCreateDTOs)
        {
            try
            {
                View(await _feedbackServices.CreateFeedback(feedbackCreateDTOs));
                return RedirectToAction("CreateFeedbacks");

            }catch (Exception ex)
            {
                throw new Exception("An error occured when we create Feedbacks");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedback()
        {
            try
            {
                FeedbackIndexDTOs feedbackIndexDTOs = new FeedbackIndexDTOs();
                feedbackIndexDTOs.FeedbackListDTOs = await _feedbackServices.GetAllFeedbacks();
                return View(feedbackIndexDTOs);

            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when we fetch all feedback", ex);
            }
        }
    }
}
