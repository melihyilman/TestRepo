//using TestRepo.Dto;

using TestRepo.Model;

namespace TestRepo.Repo
{
    public interface ICategoriesRepo : IRepository<Model.Category>
    {
        public Category GetById(int id);
    }
}
