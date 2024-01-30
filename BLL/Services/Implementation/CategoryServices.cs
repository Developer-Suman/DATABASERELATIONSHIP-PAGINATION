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
    public class CategoryServices : IcategoryServices
    {
        private readonly IUnitOfWorkTwo uow;

        public CategoryServices(IUnitOfWorkTwo unitOfWork)
        {
            uow = unitOfWork;
            
        }
        public Task<int> DeleteCategory(int CategoriesId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDTOs>> GetAllCategory()
        {
            try
            {
                var allCategory = await uow.Repository<Category>().GetAll();

                IEnumerable<CategoryDTOs> categoryDTOs = allCategory.Select(category => new CategoryDTOs
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                });

                return categoryDTOs;
                //var allCategory =await uow.Repository<Category>().GetAll();
                //List<CategoryDTOs> categoryDTOs = allCategory.Select(category => new CategoryDTOs
                //{
                //    CategoryId = category.CategoryId,
                //    CategoryName = category.CategoryName,
                //}).ToList();

                //return categoryDTOs;

            }
            catch(Exception ex)
            {
                throw new Exception("An error occured while getting all category");
            }
        }

        public Task<CategoryDTOs> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDTOs> SaveCategory(CategoryDTOs categoryDTOs)
        {
            try
            {

                List<ProductDTOs> productDTOs = categoryDTOs.Products.ToList();

                List<Product> productsList = new List<Product>();
                foreach (var productDTO in productDTOs)
                {
                    var products = new Product()
                    {
                        ProductName = productDTO.ProductName,
                        Price = productDTO.Price,
                        CategoryId = productDTO.CategoryId,

                    };
                    productsList.Add(products);
                }
               
                var categoryAdd = new Category()
                {
                    CategoryId = categoryDTOs.CategoryId,
                    CategoryName = categoryDTOs.CategoryName,
                    Products = productsList

                };

                await uow.Repository<Category>().Add(categoryAdd);
                await uow.SaveChangesAsync();
                return categoryDTOs;

            }catch(Exception ex)
            {
                throw new Exception("An error ocured while adding category", ex);
            }
        }

        public Task<CategoryDTOs> UpdateCategory(int CategoriesId, CategoryDTOs categoryDTOs)
        {
            throw new NotImplementedException();
        }
    }
}
