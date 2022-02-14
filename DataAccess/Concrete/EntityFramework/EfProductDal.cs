using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public EfProductDal(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<List<ProductDto>> GetProductDetails()
        {
            
                     var result =  from p in _appDbContext.Products
                                   join c in _appDbContext.Categories
                                   on p.CategoryId equals c.CategoryId
                                   select new ProductDto
                                   {
                                       ProductId = p.ProductId,
                                       ProductName = p.ProductName,
                                       CategoryName = c.CategoryName,
                                       UnitsInStock = p.UnitsInStock,
                                       CategoryId =c.CategoryId 
                                   };
                return await result.ToListAsync();
            
        }
       
    }
}
