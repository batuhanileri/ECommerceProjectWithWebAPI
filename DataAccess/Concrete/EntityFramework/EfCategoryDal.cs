using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category >, ICategoryDal
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public EfCategoryDal(AppDbContext context) : base(context)
        {

        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.CategoryId == categoryId);
        }
    }
}
