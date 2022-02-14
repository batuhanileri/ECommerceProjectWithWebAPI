using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);

        Task<List<ProductDto>> GetProductDetails();
    }
}
