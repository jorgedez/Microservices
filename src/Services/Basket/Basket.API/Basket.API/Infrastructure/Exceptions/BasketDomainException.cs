namespace Basket.API.Infrastructure.Exceptions
{
    using System;

    public class BasketDomainException : Exception
    {
        public BasketDomainException()
        { }

        public BasketDomainException(string message)
            : base(message)
        { }

        public BasketDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
