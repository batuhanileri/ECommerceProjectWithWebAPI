using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductDal Products { get; }
        ICategoryDal Categories { get; }
        IUserDal Users { get; }
        Task CommitAsync();//implemente ettiğimiz zaman ef tarafında ki savechanges metodunu çağırıcak
        void Commit();
    }
}
