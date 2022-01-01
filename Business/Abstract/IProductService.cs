using Core.Services;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : IService<Product>
    {

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
