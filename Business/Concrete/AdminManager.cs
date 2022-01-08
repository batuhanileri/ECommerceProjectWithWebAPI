using Business.Abstract;
using Core.DataAccess;
using DataAccess.UnitOfWorks;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AdminManager : Service<Admin>, IAdminService
    {
        public AdminManager(IUnitOfWork unitOfWork, IEntityRepository<Admin> repository) : base(unitOfWork, repository)
        {
        }
        
    }
    public class UserManager : Service<User>, IUserService
    {
        public UserManager(IUnitOfWork unitOfWork, IEntityRepository<User> repository) : base(unitOfWork, repository)
        {
        }

    }
}
