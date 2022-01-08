using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin>, IAdminDal
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public EfAdminDal(AppDbContext context) : base(context)
        {
        }

    }
}
