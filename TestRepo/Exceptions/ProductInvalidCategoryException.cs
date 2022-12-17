using System;

namespace TestRepo.Exceptions
{
    [Serializable]
    internal class ProductInvalidCategoryException : Exception
    {
        public ProductInvalidCategoryException()
            : this("Product Category")
        {
        }

        public ProductInvalidCategoryException(string message) : base(message)
        {
        }

    }
}