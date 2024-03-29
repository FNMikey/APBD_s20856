using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    internal class OverfillException : Exception
    {
        public OverfillException()
        {
        }

        public OverfillException(string message)
            : base(message)
        {
        }

        public OverfillException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
