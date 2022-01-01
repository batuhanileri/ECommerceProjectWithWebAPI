using Business.Abstract;
using Core.DataAccess;
using DataAccess.UnitOfWorks;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : Service<Product>, IProductService
    {
        public ProductManager(IUnitOfWork unitOfWork, IEntityRepository<Product> repository) : base(unitOfWork, repository)
        {
        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
