using System;

namespace sistemaCaixaMercado.Entities.Exceptions
{
    class ProductException : ApplicationException
    {
        public ProductException (string message):base(message)
        {
        }
    }
}
