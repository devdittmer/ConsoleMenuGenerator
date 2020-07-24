using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Exceptions
{
    public class ZeroRootItemsException : Exception
    {
        public ZeroRootItemsException() : base()
        {
        }

        public ZeroRootItemsException(string message) : base(message)
        {
        }
    }
}
