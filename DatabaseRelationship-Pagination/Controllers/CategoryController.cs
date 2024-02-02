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
        public async Task<IActionResult> Update()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(int CategoryId, CategoryUpdateDTOs categoryDTOs)
        {
            View(await _categoryServices.UpdateCategory(CategoryId, categoryDTOs));
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var category = await _categoryServices.GetCategoryById(Id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int CategoryId, CategoryDeleteDTOs categoryDTOs)
        {
            View(await _categoryServices.DeleteCategory(CategoryId, categoryDTOs));
            return RedirectToAction("Index");
        }
    }
}
