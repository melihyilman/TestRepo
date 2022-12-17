using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Repo
{
    public interface IRepository<T> where T : class, Model.IEntity
    {
        void Create(T e);
        void Delete(int id);
        IQueryable<T> GetList();
        void Update(T e);
    }
}
