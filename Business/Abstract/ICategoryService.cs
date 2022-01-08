using Core.Services;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
