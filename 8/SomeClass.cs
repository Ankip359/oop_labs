using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_8
{
    class SomeClass
    {
        public string data;

        public SomeClass(string Data)
        {
            data = Data;
        }

        public override string ToString()
        {
            return "Тип объекта: " + base.ToString() + $", данные: {data}";
        }
    }
}
