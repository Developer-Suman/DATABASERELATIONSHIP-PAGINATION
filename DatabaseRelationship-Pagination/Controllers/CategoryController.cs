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
            return View();
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
    }
}
