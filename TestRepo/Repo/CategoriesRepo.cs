using System;
using System.Collections.Generic;
using System.Linq;
using TestRepo.Model;

namespace TestRepo.Repo
{
    public class CategoriesRepo : ICategoriesRepo
    {
        readonly List<Category> categories = new List<Category>()
        {
            new Category(){Id=1,Name="Kategori 1"},
            new Category(){Id=2,Name="Kategori 2"},
            new Category(){Id=3,Name="Kategori 3"},
            new Category(){Id=4,Name="Kategori 4"},
            new Category(){Id=5,Name="Kategori 5"},
            new Category(){Id=6,Name="Kategori 6"},
            new Category(){Id=7,Name="Kategori 7"},
            new Category(){Id=8,Name="Kategori 8"},
        };

        public Category GetById(int id)
        {
            return categories.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Category e)
        {
            categories.Add(e);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Category e)
        {
            throw new NotImplementedException();
        }
    }
}
