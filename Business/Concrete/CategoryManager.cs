using Business.Abstract;
using Core.DataAccess;
using DataAccess.UnitOfWorks;
using Entities.Concrete;
using System.Threading.Tasks;
using Business.Services;

namespace Business.Concrete
{
    public class CategoryManager : Service<Category>, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork, IEntityRepository<Category> repository) : base(unitOfWork, repository)
        {
        }


        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
