using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_9
{
    class ClassEvent
    {
        public void DoResize(MyClass obj, int size)
        {
            obj.size = size;
        }

        public void DoCoordinates(MyClass obj, int x, int y)
        {
            obj.x = x;
            obj.y = y;
        }
    }
}
