using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(ProductViewModel productViewModel)
        {
            return View();
        }
    }
}
