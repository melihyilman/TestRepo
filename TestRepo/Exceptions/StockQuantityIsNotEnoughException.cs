using System;

namespace TestRepo.Exceptions
{
    [Serializable]
    internal class StockQuantityIsNotEnoughException : Exception
    {
        public StockQuantityIsNotEnoughException()
            : this("StockQuantityIsNotEnoughException")
        {
        }

        public StockQuantityIsNotEnoughException(string message) : base(message)
        {
        }

    }
}