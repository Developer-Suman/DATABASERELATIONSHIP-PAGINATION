using BLL.DTOs;
using BLL.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IProductServices 
    {
        Task<List<ProductGetDTOs>> GetAllProduct();
        Task<ProductGetDTOs> GetProductById(int id);
        Task<ProductGetDTOs> SaveProduct(ProductCreateDTOs productDTOs);
        Task<ProductGetDTOs> UpdateProduct(ProductUpdateDTOs productDTOs);
        Task<int?> DeleteProduct(int ProductsId);
    }
}
