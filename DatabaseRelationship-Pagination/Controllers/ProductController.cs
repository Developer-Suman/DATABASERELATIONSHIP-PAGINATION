
using BLL.DTOs;
using BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTOs productViewModel)
        {
            View(_productServices.SaveProduct(productViewModel));
            return RedirectToAction("Index");
        }
    }
}
