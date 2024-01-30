using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IcategoryServices
    {
        Task<IList<CategoryDTOs>> GetAllCategory();
        Task<CategoryDTOs> GetCategoryById(int id);
        Task<CategoryDTOs> SaveCategory(CategoryDTOs categoryDTOs);
        Task<CategoryDTOs> UpdateCategory(int CategoriesId, CategoryDTOs categoryDTOs);
        Task<CategoryDTOs> DeleteCategory(int CategoriesId, CategoryDTOs categoryDTOs);

    }
}
