using System.Collections;
using System.Collections.Generic;
using TestRepo.Model;

namespace TestRepo.Repo
{
    public interface IProductsRepo : IRepository<Model.Product>
    {
        public IEnumerable<Product> GetListByTextSearch(string keyword);
        public IEnumerable<Product> GetListBetweenQuantities(int min, int max);
    }
}
