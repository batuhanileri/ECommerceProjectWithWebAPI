using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public EfUserDal(AppDbContext context) : base(context)
        {
        }

    }
}
