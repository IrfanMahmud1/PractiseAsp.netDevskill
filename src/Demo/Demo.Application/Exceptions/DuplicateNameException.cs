using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Exceptions
{
    public class DuplicateNameException : Exception
    {
        public DuplicateNameException() : base("Name can't be duplicate.")
        {

        }
    }
}
