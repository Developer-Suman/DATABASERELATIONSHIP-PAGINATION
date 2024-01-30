using BLL.DTOs;
using BLL.Repository.Interface;
using BLL.Services.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async Task<CategoryDTOs> DeleteCategory(int CategoriesId, CategoryDTOs categoryDTOs)
        {
            try
            {
                var category = await uow.Repository<Category>().GetById(CategoriesId) ?? throw new Exception("Category not found");
                uow.Repository<Category>().Delete(category);
                await uow.SaveChangesAsync();
                var categoryDTO = new CategoryDTOs()
                {
                    CategoryName = category.CategoryName
                };
                return categoryDTO;



            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while deleteing Categories");
            }
        }

        public async Task<IList<CategoryDTOs>> GetAllCategory()
        {
            try
            {
                var allCategory = await uow.Repository<Category>().GetAll();

                

                IList<CategoryDTOs> categoryDTOs = allCategory.Select(category => new CategoryDTOs
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                }).ToList();


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

        public async Task<CategoryDTOs> GetCategoryById(int id)
        {
            var category = await uow.Repository<Category>().GetById(id);
            var categoryDTOs = new CategoryDTOs()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return categoryDTOs;
        }

        public async Task<CategoryDTOs> SaveCategory(CategoryDTOs categoryDTOs)
        {
            try
            {

                List<ProductDTOs> productDTOs = categoryDTOs.Products.ToList();

                IEnumerable<Product> productLst = productDTOs.Select(product => new Product
                {
                    ProductName = product.ProductName,
                    CategoryId = product.CategoryId,

                });

                List<Product> productList = productLst.ToList();

                //IList<Product> productList = productDTOs.Select(product => new Product
                //{
                //    ProductName = product.ProductName,
                //    Price = product.Price,
                //    CategoryId = product.CategoryId,

                //}).ToList();




                var categoryAdd = new Category()
                {
                    CategoryName = categoryDTOs.CategoryName,
                    Products = productList,

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
