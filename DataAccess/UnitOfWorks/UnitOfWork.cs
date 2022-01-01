using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private EfProductDal _productRepository;

        private EfCategoryDal _categoryRepository;
        public IProductDal Products => _productRepository = _productRepository ?? new EfProductDal(_appDbContext);

        public ICategoryDal Categories => _categoryRepository = _categoryRepository ?? new EfCategoryDal(_appDbContext);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
