using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_9
{
    class MyClass
    {
        public int x;
        public int y;
        public int size;

        public delegate void Resize(MyClass obj, int size);
        public delegate void Coordinates(MyClass obj, int x, int y);
        public event Resize resize;
        public event Coordinates coord;

        public MyClass(int size, int x, int y)
        {
            this.size = size;
            this.x = x;
            this.y = y;
        }

        public void Action(int size, int x, int y)
        {
            Console.WriteLine(ToString());
            Console.Write("Изменения объекта: ");

            if (resize != null)
            {
                resize(this, size);
                Console.Write($"Новый размер объекта = {size}. ");
            }
            else
            {
                Console.Write("Размер не изменён. ");
            }

            if (coord != null)
            {
                coord(this, x, y);
                Console.Write($"Новые координаты объекта: x = {x}, y = {y}. ");
            }
            else
            {
                Console.Write("Координаты не изменены. ");
            }

            Console.WriteLine();
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Текущие параметры объекта: размер = {this.size}, x = {this.x}, y = {this.y}";
        }
    }
}
