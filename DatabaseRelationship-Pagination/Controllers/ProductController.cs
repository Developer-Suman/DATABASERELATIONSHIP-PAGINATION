
using BLL.DTOs;
using BLL.Services.Interface;
using DAL.DbContext;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IcategoryServices _categoryServices;

        public ProductController(IProductServices productServices, IcategoryServices icategoryServices)
        {
            _productServices = productServices;
            _categoryServices = icategoryServices;


        }
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<CategoryDTOs> category = await _categoryServices.GetAllCategory();


            ViewBag.Category = new SelectList(category, "CategoryId", "CategoryName");
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTOs productViewModel)
        {
            View(await _productServices.SaveProduct(productViewModel));
            return RedirectToAction("Index");
        }
    }
}
