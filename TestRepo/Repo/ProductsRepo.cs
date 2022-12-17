using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TestRepo.Exceptions;
using TestRepo.Model;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace TestRepo.Repo
{
    public class ProductsRepo : IProductsRepo
    {
        readonly List<Product> products = new List<Product>()
        {
        };

        IMapper Mapper { get; }
        ICategoriesRepo categoriesRepo;
        public ProductsRepo(IMapper mapper, ICategoriesRepo categoriesRepo)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.categoriesRepo = categoriesRepo;
        }

        public IQueryable<Product> GetList()
        {
            return products.Select(Mapper.Map<Product>).AsQueryable();
        }

        public void Create(Product p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            if (products.Any(x => x.Id == p.Id))
            {
                throw new DuplicateKeyException($"Can't create an object of a type {nameof(Product)} with the key '{p.Id}'. The object with the same key is already exists");
            }
            if(string.IsNullOrWhiteSpace(p.Title) || p.Title.Length > 200)
            {
                throw new ProductTitleIsNotAllowedException($"Can't create an object of a type {nameof(Product)} with the Title : {p.Title}, it's empty or size's larger than 200");
            }
            if (p.CategoryId==0)
            {
                throw new ProductInvalidCategoryException($"Can't create an object of a type {nameof(Product)} with the Category : {p.CategoryId}, it's empty");
            }
            p.Category = categoriesRepo.GetById(p.CategoryId);

            products.Add(Mapper.Map<Product>(p));
        }

        public void Delete(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                throw new KeyNotFoundException($"An object of a type '{nameof(Product)}' with the key '{id}' not found");
            }

            products.RemoveAll(x => x.Id == p.Id);
        }

        public void Update(Product p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            var stored = products.FirstOrDefault(x => x.Id == p.Id);
            if (stored == null)
            {
                throw new KeyNotFoundException($"An object of a type '{nameof(Product)}' with the key '{p.Id}' not found");
            }

            products.RemoveAll(x => x.Id == stored.Id);
            products.Add(Mapper.Map<Product>(p));
        }

        public IEnumerable<Product> GetListByTextSearch(string keyword)
        {
            return products.Where(x=>x.Description.ToLower().Contains(keyword) || x.Title.ToLower().Contains(keyword))
                .Select(Mapper.Map<Product>).ToList();
        }

        public IEnumerable<Product> GetListBetweenQuantities(int min, int max)
        {
            return products.Where(x => x.Quantity>= min && x.Quantity<=max)
                .Select(Mapper.Map<Product>).ToList();
        }
    }
}
