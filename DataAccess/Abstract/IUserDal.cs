using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    { 
        Task<List<OperationClaim>> GetClaims(User user);
        Task<User> GetByMail(string Email);
        
    }
}
