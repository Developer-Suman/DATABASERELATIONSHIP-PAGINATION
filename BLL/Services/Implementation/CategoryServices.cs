using BLL.DTOs;
using BLL.DTOs.Category;
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

        public async Task<CategoryDeleteDTOs> DeleteCategory(int CategoriesId, CategoryDeleteDTOs categoryDeleteDTOs)
        {
            try
            {
                var category = await uow.Repository<Category>().GetById(CategoriesId) ?? throw new Exception("Category not found");
                uow.Repository<Category>().Delete(category);
                await uow.SaveChangesAsync();
                var categoryDTO = new CategoryDeleteDTOs()
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

        public async Task<IList<CategoryGetAllDTOs>> GetAllCategory()
        {
            try
            {
                var allCategory = await uow.Repository<Category>().GetAll();

                

                IList<CategoryGetAllDTOs> categoryDTOs = allCategory.Select(category => new CategoryGetAllDTOs
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

        public async Task<CategoryGetByIdDTOs> GetCategoryById(int id)
        {
            var category = await uow.Repository<Category>().GetById(id);
            var categoryDTOs = new CategoryGetByIdDTOs()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return categoryDTOs;
        }

        public async Task<CategoryCreateDTOs> SaveCategory(CategoryCreateDTOs categoryCreateDTOs)
        {
            try
            {

                List<ProductDTOs> productDTOs = categoryCreateDTOs.Products.ToList();

                //IEnumerable<Product> productLst = productDTOs.Select(product => new Product
                //{
                //    ProductName = product.ProductName,
                //    CategoryId = product.CategoryId,

                //});

                //List<Product> productList = productLst.ToList();

                IList<Product> productList = productDTOs.Select(product => new Product
                {
                    ProductName = product.ProductName,
                    Price = product.Price,
                    CategoryId = product.CategoryId,

                }).ToList();




                var categoryAdd = new Category()
                {
                    CategoryName = categoryCreateDTOs.CategoryName,
                    Products = productList,

                };

                await uow.Repository<Category>().Add(categoryAdd);
                await uow.SaveChangesAsync();
                return categoryCreateDTOs;

            }catch(Exception ex)
            {
                throw new Exception("An error ocured while adding category", ex);
            }
        }

        public Task<CategoryUpdateDTOs> UpdateCategory(int CategoriesId, CategoryUpdateDTOs categoryDTOs)
        {
            throw new NotImplementedException();
        }

       
    }
}
