using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Categories;
using BLL.DTOs.Category;
using BLL.DTOs.Products;
using BLL.Repository.Interface;
using BLL.Services.Interface;
using DAL.DbContext;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryServices(IUnitOfWorkTwo unitOfWork,ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            uow = unitOfWork;
            _context = applicationDbContext;
            _mapper = mapper;
            
        }

        public async Task<int?> DeleteCategory(int CategoriesId)
        {
            try
            {
                var category = await uow.Repository<Category>().GetById(CategoriesId) ?? throw new Exception("Category not found");
                uow.Repository<Category>().Delete(category);
                await uow.SaveChangesAsync();
                return category.CategoryId;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new Exception("An error occurred while deleting Categories", ex); // Include the original exception as inner exception
            }
        }


        public async Task<List<CategoryGetDTOs>> GetAllCategoriesWithProducts()
        {
            try
            {


                //List<CategoryGetAllDTOs> categoriswithproduct = _context.Categories.Include(x => x.Products)
                //    .Select(x => new CategoryGetAllDTOs()
                //{
                //        CategoryName = x.CategoryName,
                //        CategoryId = x.CategoryId,
                //        Products = x.Products.Select(x => new ProductDTOs()
                //        {
                //            ProductName = x.ProductName,
                //            Price = x.Price,

                //        }).ToList()

                //}).ToList();

                List<CategoryGetDTOs> categoriswithproduct = _context.Categories.Include(x=>x.Products)
                    .Select(category => new CategoryGetDTOs()
                    {
                        CategoryName = category.CategoryName,
                        CategoryId = category.CategoryId,
                        Products = category.Products.Select(x=>_mapper.Map<ProductGetDTOs>(x)).ToList()
                    }).ToList();



                return categoriswithproduct;

            }catch(Exception ex)
            {
                throw new Exception("An error occured while getting all category with products");
            }
        }

        public async Task<List<CategoryGetDTOs>> GetAllCategory()
        {
            try
            {

                List<CategoryGetDTOs> allCategories = _context.Categories
                .Select(category => _mapper.Map<CategoryGetDTOs>(category))
                .ToList();




                //var category = await uow.Repository<Category>().GetAll();
                //List<CategoryGetAllDTOs> AllCategories= category.Select(x => new CategoryGetAllDTOs()
                //{
                //    CategoryId = x.CategoryId,
                //    CategoryName = x.CategoryName,

                //}).ToList();

                return allCategories;

            }
            catch(Exception ex)
            {
                throw new Exception("An eror occured while fetch all the category");
            }
        }


        public async Task<CategoryGetDTOs> GetCategoryById(int id)
        {
            var category = await uow.Repository<Category>().GetById(id);
            var categoryDTOs = new CategoryGetDTOs()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return categoryDTOs;
        }

        public async Task<List<ProductGetDTOs>> GetProductFromCategories()
        {
            try
            {
                List<ProductGetDTOs> productsByCategories = await _context.Categories.SelectMany(x => x.Products
                .Select(x => new ProductGetDTOs()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    CategoryName = x.Category.CategoryName,
                    Price = x.Price,

                })).ToListAsync();

                return productsByCategories;

            }
            catch(Exception ex) 
            {
                throw new Exception("An error occured while getting product from Category");
             }
        }

        public async Task<CategoryGetDTOs> SaveCategory(CategoryCreateDTOs categoryCreateDTOs)
        {
            try
            {

                List<ProductGetDTOs> productDTOs = categoryCreateDTOs.Products.ToList();

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
                var categoryDTOs = _mapper.Map<CategoryGetDTOs>(categoryAdd);
                await uow.SaveChangesAsync();
                return categoryDTOs;

            }catch(Exception ex)
            {
                throw new Exception("An error ocured while adding category", ex);
            }
        }

        public async Task<CategoryGetDTOs> UpdateCategory(CategoryUpdateDTOs categoryDTOs)
        {
            try
            {
                var category = await uow.Repository<Category>().GetById(categoryDTOs.CategoryId) ?? throw new Exception("Category Not Found");
               
                _mapper.Map(categoryDTOs, category);
                await uow.SaveChangesAsync();

                return _mapper.Map<CategoryGetDTOs>(category);

            }catch( Exception ex)
            {
                throw new Exception("An error occured while updating");
            }
        }

       
    }
}
