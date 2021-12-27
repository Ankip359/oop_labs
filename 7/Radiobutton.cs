using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    class Radiobutton : ControlElement, IControl
    {
        public Radiobutton(int size, bool otherRadio) : base(size)
        {
            this.otherRadio = otherRadio;
        }

        public bool otherRadio;

        public void ShowInfo()
        {
            Console.WriteLine($"Наличие другие radiobutton: {otherRadio}");
        }

        public override string ToString()
        {
            return $"Тип объекта: {base.ToString()}, состояние: {status}, размер: {size}, наличие другие radiobutton: {otherRadio}";
        }
    }
}
