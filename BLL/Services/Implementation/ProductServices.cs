using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Products;
using BLL.Repository.Interface;
using BLL.Services.Interface;
using DAL.DbContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWorkTwo uow;
        private readonly IMapper _mapper;
       private readonly ApplicationDbContext _context;

        public ProductServices(IUnitOfWorkTwo unitOfWork, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            uow = unitOfWork;
            _context = applicationDbContext;
            
        }
        public Task<int> DeleteProduct(int ProductsId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductGetDTOs>> GetAllProduct()
        {
            try
            {
                var AllProducts = await _context.Products.AsNoTracking().Include(x=>x.Category).ToListAsync();
                                       

                List<ProductGetDTOs> products = AllProducts.Select(product => new ProductGetDTOs
                {
                    ProductName = product.ProductName,
                    ProductId = product.ProductId,
                    Price = product.Price,
                    CategoryName = product.Category.CategoryName

                }).ToList();

                return products;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while getting all product", ex);
            }
        }

        public async Task<ProductGetDTOs> GetProductById(int id)
        {
            try
            {
                var product = await uow.Repository<Product>().GetById(id);
                if(product == null)
                {
                    throw new Exception("Product contains null");
                }
                var productDTO = _mapper.Map<ProductGetDTOs>(product);
                return productDTO;

            }catch (Exception ex)
            {
                throw new Exception("An error occured while getting Product by Id", ex);
            }
        }

        public async Task<ProductGetDTOs> SaveProduct(ProductCreateDTOs productDTOs)
        {
            try
            {
                var productAdd = new Product()
                {
                    Price = productDTOs.Price,
                    ProductName = productDTOs.ProductName,
                    CategoryId = productDTOs.CategoryId


                };

                var productshow = new ProductGetDTOs()
                {
                    Price = productDTOs.Price,
                    ProductName = productDTOs.ProductName,
                    //CategoryId = productDTOs.CategoryId,

                };
                await uow.Repository<Product>().Add(productAdd);
                await uow.SaveChangesAsync();
                return productshow;


            }
            catch (Exception ex)
            {
                throw new Exception("An error occur while creating product", ex);
            }
        }

        public Task<ProductGetDTOs> UpdateProduct(int ProductsId, ProductUpdateDTOs productDTOs)
        {
            throw new NotImplementedException();
        }
    }
}
