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
                if(ModelState.IsValid)
                {
                    View(await _feedbackServices.CreateFeedback(feedbackCreateDTOs));

                }
                
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

        [HttpGet]
        public async Task<IActionResult> UpdateFeedback(int Id)
        {
            FeedbackGetDTOs feedbackGetDTOs = await _feedbackServices.GetFeedbacksById(Id);
            return PartialView(feedbackGetDTOs);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeedback(FeedbackUpdateDTOs feedbackUpdateDTOs)
        {
            try
            {
                await _feedbackServices.UpdateFeedback(feedbackUpdateDTOs);
                return Json(true);

            }catch(Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFeedback(int FeedbackId)
        {
            try
            {
                await _feedbackServices.DeleteFeedback(FeedbackId);
                return Json(true);

            }catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}
