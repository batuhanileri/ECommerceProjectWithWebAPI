using Core.Entities.Concrete;
using Core.Services;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IService<User>
    {
        Task<List<OperationClaim>> GetClaims(User user);
        Task<User> GetByMail(string email);
        
    }
}
