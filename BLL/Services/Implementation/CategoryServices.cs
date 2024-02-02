using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Category;
using BLL.DTOs.Products;
using BLL.Repository.Interface;
using BLL.Services.Interface;
using DAL.DbContext;
using DAL.Models;
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

        public async Task<List<CategoryGetAllDTOs>> GetAllCategoriesWithProducts()
        {
            try
            {
                List<CategoryGetAllDTOs> categoriswithproduct = _context.Categories.Include(x => x.Products)
                    .Select(x => new CategoryGetAllDTOs()
                {
                        CategoryName = x.CategoryName,
                        CategoryId = x.CategoryId,
                        Products = x.Products.Select(x => new ProductDTOs()
                        {
                            ProductName = x.ProductName,
                            Price = x.Price,

                        }).ToList()

                }).ToList();

                return categoriswithproduct;

            }catch(Exception ex)
            {
                throw new Exception("An error occured while getting all category with products");
            }
        }

        public async Task<List<CategoryGetAllDTOs>> GetAllCategory()
        {
            try
            {
                var category = await uow.Repository<Category>().GetAll();
                List<CategoryGetAllDTOs> AllCategories= category.Select(x => new CategoryGetAllDTOs()
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,

                }).ToList();

                return AllCategories;

            }
            catch(Exception ex)
            {
                throw new Exception("An eror occured while fetch all the category");
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

        public async Task<List<ProductGetAllDTOs>> GetProductFromCategories()
        {
            try
            {
                List<ProductGetAllDTOs> productsByCategories = await _context.Categories.SelectMany(x => x.Products
                .Select(x => new ProductGetAllDTOs()
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
