using TestRepo.Model;

namespace TestRepo.Dto
{
    /// <summary>
    /// DTO for creating and updating product
    /// </summary>
    public class UpdateProduct
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

    }
}
