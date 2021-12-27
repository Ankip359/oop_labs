using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    abstract class ControlElement
    {
        public bool status;
        public int size;
        public int Size
        { 
            get
            {
                return size;
            }
            set
            {
                if (value <= 0) throw new CEException("размер элемента не может быть меньше нуля", GetType().Name);
                size = value;
            }
        }

        public ControlElement(int size)
        {
            this.Size = size;
            status = false;
        }

        public virtual void Resize(int multiplication)
        {
            size *= multiplication;
        }
    }
}
