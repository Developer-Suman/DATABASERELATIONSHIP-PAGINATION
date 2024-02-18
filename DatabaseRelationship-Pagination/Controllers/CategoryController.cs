using BLL.DTOs;
using BLL.DTOs.Categories;
using BLL.DTOs.Category;
using BLL.Services.Interface;
using DAL.DbContext;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class CategoryController : Controller
    {
       private readonly IcategoryServices _categoryServices;
        private readonly ApplicationDbContext _context;

        public CategoryController(IcategoryServices icategoryServices, ApplicationDbContext context)
        {
            _categoryServices = icategoryServices;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //List<Product> testSelectMany = await _context.Categories.AsNoTracking().SelectMany(x => x.Products).ToListAsync();
            //var categoryWithProduct  = _context.Products.ToLookup(x => x.ProductId);
            CategoryIndexDTOs categoryIndexDTOs = new CategoryIndexDTOs();
            categoryIndexDTOs.CategoryListDTOs = await _categoryServices.GetAllCategory();
            return View(categoryIndexDTOs);
        }


        [HttpGet]
        public async Task<IActionResult> GetCategoryWithProduct()
        {
            CategoryIndexDTOs categoryIndexDTOs = new CategoryIndexDTOs();
            categoryIndexDTOs.CategoryListDTOs = await _categoryServices.GetAllCategoriesWithProducts();
            return View(categoryIndexDTOs);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductFromCategories()
        {
            CategoryIndexDTOs categoryIndexDTOs = new CategoryIndexDTOs();
            categoryIndexDTOs.ProductGetAllDTOs = await _categoryServices.GetProductFromCategories();
            return View(categoryIndexDTOs);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTOs categoryCreateDTOs)
        {
           View(await _categoryServices.SaveCategory(categoryCreateDTOs));
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            CategoryGetDTOs categoryGetDTOs= await _categoryServices.GetCategoryById(Id);
            return PartialView(categoryGetDTOs);
        }


        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDTOs categoryDTOs)
        {
            try
            {
                await _categoryServices.UpdateCategory(categoryDTOs);
                return Json(true);

            }
            catch(Exception ex)
            {
                return Json(false);

            }

        }

       

        [HttpPost]
        public async Task<IActionResult> Delete(int CategoryId)
        {
            try
            {
                var deleteId = await _categoryServices.DeleteCategory(CategoryId);
                if (deleteId == null)
                {
                    throw new Exception("Delete Item is not Found");
                }
                return Json(true);

            }catch(Exception ex)
            {
                throw new Exception("An error occured while Deleting Category");
            }
       
        }
    }
}
