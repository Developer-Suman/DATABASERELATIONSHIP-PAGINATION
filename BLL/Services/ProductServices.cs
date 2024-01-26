using BLL.DTOs;
using DAL.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductServices
    {
        private readonly ApplicationDbContext _context;
        public ProductServices(ApplicationDbContext applicationDbContext) 
        {
            _context = applicationDbContext;

        }

        //public void CreateProduct(ProductDTOs productDTOs)
        //{
        //    _context.

        //}
    }
}
