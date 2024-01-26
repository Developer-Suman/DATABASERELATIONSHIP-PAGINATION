
//using DAL.DbContext;
//using DAL.Models;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Services
//{
//    public class CategoryServices
//    {
//        private readonly ApplicationDbContext _context;
//        public CategoryServices(ApplicationDbContext applicationDbContext)
//        {
//            _context = applicationDbContext;

//        }

//        public void CreateCategory(CategoryDTOs categoryDTOs)
//        {
//            Category category = new Category()
//            {
//                CategoryName = categoryDTOs.CategoryName,
//                Products = _context.Products.Select(p => new Product()
//                {
//                    ProductName = p.ProductName,
//                    Price = p.Price,
//                }).ToList()


//            };

//            _context.Categories.Add(category);
//            _context.SaveChanges();
//        }
//    }
//}
