using System;

namespace TestRepo.Model
{
    public class Product : IEntity
    {
        public Product()
        {
        }

        public Product(int id)
        {
            Id = id;
        }

        public Product(int id, string title)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int Quantity { get; set; }
    }
}
