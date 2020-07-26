using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Exceptions
{
    public class MultipleRootMenuException : Exception
    {
        public MultipleRootMenuException() : base ()
        {
        }

        public MultipleRootMenuException(string message) : base(message)
        {
        }
    }
}
