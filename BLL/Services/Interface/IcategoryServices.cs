using BLL.DTOs;
using BLL.DTOs.Categories;
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
        Task<List<CategoryGetDTOs>> GetAllCategory();
        Task<List<CategoryGetDTOs>> GetAllCategoriesWithProducts();
        Task<List<ProductGetDTOs>> GetProductFromCategories();
        Task<CategoryGetDTOs> GetCategoryById(int id);
        Task<CategoryGetDTOs> SaveCategory(CategoryCreateDTOs categoryDTOs);
        Task<CategoryGetDTOs> UpdateCategory(CategoryUpdateDTOs categoryUpdateDTOs);
        Task<int?> DeleteCategory(int CategoriesId);

    }
}
