using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public EfUserDal(AppDbContext context) : base(context)
        {

        }
        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            
                var result = from OperationClaim in _appDbContext.OperationClaims
                             join UserOperationClaim in _appDbContext.UserOperationClaims
                                 on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };
                return await result.ToListAsync();

            
        }
    }
}

