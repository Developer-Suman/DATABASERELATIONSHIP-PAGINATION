using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IProductServices 
    {
        Task<List<ProductDTOs>> GetAllProduct();
        Task<ProductDTOs> GetProductById(int id);
        Task<ProductDTOs> SaveProduct(ProductDTOs productDTOs);
        Task<ProductDTOs> UpdateProduct(int ProductsId,ProductDTOs productDTOs);
        Task<int> DeleteProduct(int ProductsId);
    }
}
