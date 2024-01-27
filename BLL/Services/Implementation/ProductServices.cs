using BLL.DTOs;
using BLL.Repository.Interface;
using BLL.Services.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork uow;

        public ProductServices(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
            
        }
        public Task<int> DeleteProduct(int ProductsId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDTOs>> GetAllProduct()
        {
            try
            {
                var AllProducts = await uow.Repository<Product>().GetAll();

                List<ProductDTOs> products = AllProducts.Select(product => new ProductDTOs
                {
                    ProductName = product.ProductName,
                    ProductId = product.ProductId,
                    Price = product.Price,

                }).ToList();

                return products;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while getting all product", ex);
            }
        }

        public Task<ProductDTOs> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTOs> SaveProduct(ProductDTOs productDTOs)
        {
            try
            {
                var productAdd = new Product()
                {
                    ProductId = productDTOs.ProductId,
                    Price = productDTOs.Price,
                    ProductName = productDTOs.ProductName,

                };

                var productshow = new ProductDTOs()
                {
                    ProductId = productDTOs.ProductId,
                    Price = productDTOs.Price,
                    ProductName = productDTOs.ProductName,

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

        public Task<ProductDTOs> UpdateProduct(int ProductsId, ProductDTOs productDTOs)
        {
            throw new NotImplementedException();
        }
    }
}
