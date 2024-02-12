using BLL.DTOs;
using BLL.DTOs.Category;
using BLL.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IcategoryServices
    {
        Task<List<CategoryGetAllDTOs>> GetAllCategory();
        Task<List<CategoryGetAllDTOs>> GetAllCategoriesWithProducts();
        Task<List<ProductGetDTOs>> GetProductFromCategories();
        Task<CategoryGetByIdDTOs> GetCategoryById(int id);
        Task<CategoryCreateDTOs> SaveCategory(CategoryCreateDTOs categoryDTOs);
        Task<CategoryUpdateDTOs> UpdateCategory(int CategoriesId, CategoryUpdateDTOs categoryUpdateDTOs);
        Task<CategoryDeleteDTOs> DeleteCategory(int CategoriesId, CategoryDeleteDTOs categoryDTOs);

    }
}
