using Business.Abstract;
using Business.Services;
using Core.DataAccess;
using DataAccess.UnitOfWorks;
using Entities.Concrete;
using Entities.DTOs;
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

        public async Task<IEnumerable<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return await _unitOfWork.Products.GetAllAsync(x => x.UnitPrice >= min && x.UnitPrice <= max);
        }

        public async Task<List<ProductDto>> GetProductDetails()
        {
            return await _unitOfWork.Products.GetProductDetails();
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }

        
    }
}
