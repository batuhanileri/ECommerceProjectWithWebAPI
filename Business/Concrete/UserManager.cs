using Business.Abstract;
using Business.Services;
using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : Service<User>, IUserService
    {
        public UserManager(IUnitOfWork unitOfWork, IEntityRepository<User> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {

            return await _unitOfWork.Users.GetClaims(user);

        }


        public async Task<User> GetByMail(string email)
        {
            return await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == email); 
        }
    }
}
