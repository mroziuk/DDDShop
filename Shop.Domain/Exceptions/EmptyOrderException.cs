using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Exceptions
{
    public class EmptyOrderException : Exception
    {
        public EmptyOrderException() : base("cant place order without products") { }
    }
}
