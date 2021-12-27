using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Лаба_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle cr = new Circle("чёрный", 5);
            Circle cr2 = new Circle("чёрный", 5);
            Circle cr3 = new Circle("белый", 56);
            Rectangle re = new Rectangle("чёрный", 2, 6); // struct

            Checkbox cb = new Checkbox(77, Checkbox.Color.фиолетовый); // enum
            Radiobutton rb = new Radiobutton(5, false);
            Button bt = new Button(10);

            List<object> list1 = new List<object> { cr, cr2, cr3, re, cb, rb, bt };
            Container container = new Container();
            container.mainList = list1;

            container.PrintElems();
            Rectangle re2 = new Rectangle("красный", 21, 4);
            container.Add(re2);
            container.Remove(2);
            Console.WriteLine("------------------------------------");
            container.PrintElems();

            Console.WriteLine("------------------------------------");
            Controller cntr = new Controller();
            cntr.Buttons(container);
            cntr.Sum(container);
            cntr.TotalSquare(container);
        }
    }

    internal sealed partial class Circle : GeometricFigure, IGeometricFigure
    {
        public override string ToString()
        {
            return "Тип объекта: " + base.ToString() + $", цвет: {color}, радиус: {radius}, периметр: {perimeter}, площадь: {square}";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType() && ((Circle)obj).color == color && ((Circle)obj).radius == radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hash = 269;
            hash *= (radius % 2 == 0) ? 24 : 99;
            hash = (hash * 47) + radius;
            return hash;
        }
    }
}
