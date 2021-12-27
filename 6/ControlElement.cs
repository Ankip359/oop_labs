using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    abstract class ControlElement
    {
        public bool status;
        public int size;

        public ControlElement(int size)
        {
            this.size = size;
            status = false;
        }

        public virtual void Resize(int multiplication)
        {
            size *= multiplication;
        }
    }
}
