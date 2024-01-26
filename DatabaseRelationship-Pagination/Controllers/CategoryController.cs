using BLL.DTOs;
using BLL.Services;
using DAL.DbContext;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class CategoryController : Controller
    {
       private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDTOs categoryDTOs)
        {
            Category category = new Category()
            {
                CategoryName = categoryDTOs.CategoryName,
                Products = _context.Products.Select(p => new Product()
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                }).ToList()


            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
