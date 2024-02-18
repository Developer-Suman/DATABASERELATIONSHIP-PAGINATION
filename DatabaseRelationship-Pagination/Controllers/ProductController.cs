
using BLL.DTOs;
using BLL.DTOs.Categories;
using BLL.DTOs.Category;
using BLL.DTOs.Products;
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
       
       

        public async Task<IActionResult> GetAllProducts()
        {
            ProductIndexDTOs productIndexDTOs = new ProductIndexDTOs();
            productIndexDTOs.productGetDTOs = await _productServices.GetAllProduct();

            return View(productIndexDTOs);

        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<CategoryGetDTOs> category = await _categoryServices.GetAllCategory();


            ViewBag.Category = new SelectList(category, "CategoryId", "CategoryName");
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTOs productViewModel)
        {
            View(await _productServices.SaveProduct(productViewModel));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int Id)
        {
            ProductIndexDTOs productIndexDTOs = new ProductIndexDTOs();
            productIndexDTOs.ProductGetDTOs = await _productServices.GetProductById(Id);
            return View(productIndexDTOs);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProducts(int Id)
        {
            ProductGetDTOs productgetDTOs = await _productServices.GetProductById(Id);
            return PartialView(productgetDTOs);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProducts(ProductUpdateDTOs productUpdateDTOs)
        {
            try
            {
                var product = await _productServices.UpdateProduct(productUpdateDTOs);
                return Json(true);

            }catch(Exception ex)
            {
                return Json(false);

            }

        }


        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var deleteProduct = await _productServices.DeleteProduct(productId);
                if(deleteProduct == null)
                {
                    throw new Exception("Deleted Item is not found");
                }
                return Json(true);

            }catch(Exception ex)
            {
                throw new Exception("An error occured while Deleting");
            }
        }
    }
}
