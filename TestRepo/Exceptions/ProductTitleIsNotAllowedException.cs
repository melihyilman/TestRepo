using System;

namespace TestRepo.Exceptions
{
    [Serializable]
    internal class ProductTitleIsNotAllowedException : Exception
    {
        public ProductTitleIsNotAllowedException()
            : this("Product Title")
        {
        }

        public ProductTitleIsNotAllowedException(string message) : base(message)
        {
        }

    }
}