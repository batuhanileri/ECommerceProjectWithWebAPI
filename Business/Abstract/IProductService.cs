using Core.Services;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : IService<Product>
    {

        Task<Product> GetWithCategoryByIdAsync(int productId);
        Task<IEnumerable<Product>> GetByUnitPrice(decimal min, decimal max);
        Task<List<ProductDto>> GetProductDetails();
        Task<Product> ProductAddAsync(Product product);

    }
}
