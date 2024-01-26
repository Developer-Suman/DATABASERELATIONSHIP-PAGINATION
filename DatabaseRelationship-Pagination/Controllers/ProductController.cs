
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(ProductDTOs productViewModel)
        {
            return View();
        }
    }
}
