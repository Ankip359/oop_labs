using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Лаба_10
{
    class Book
    {
        public string name;

        public Book(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return base.ToString() + $", название: {name}.";
        }
    }
}
