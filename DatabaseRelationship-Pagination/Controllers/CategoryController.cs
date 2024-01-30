using BLL.DTOs;
using BLL.Services.Interface;
using DAL.DbContext;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class CategoryController : Controller
    {
       private readonly IcategoryServices _categoryServices;

        public CategoryController(IcategoryServices icategoryServices)
        {
           _categoryServices = icategoryServices;
            
        }


        public async Task<IActionResult> Index()
        {
            IList<CategoryDTOs> categoryList = await _categoryServices.GetAllCategory();
            return View(categoryList);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTOs categoryDTOs)
        {
           View(await _categoryServices.SaveCategory(categoryDTOs));
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(int CategoryId, CategoryDTOs categoryDTOs)
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
        public async Task<IActionResult> Delete(int CategoryId, CategoryDTOs categoryDTOs)
        {
            View(await _categoryServices.DeleteCategory(CategoryId, categoryDTOs));
            return RedirectToAction("Index");
        }
    }
}
