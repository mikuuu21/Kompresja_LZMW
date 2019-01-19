using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Compression.Classes
{
    public class CustomExceptions: Exception
    {

        public CustomExceptions(string message) : base(message) { }
    }
}