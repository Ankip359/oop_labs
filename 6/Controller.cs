using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    class Controller
    {
        public void Buttons(Container ct)
        {
            foreach (object item in ct.list)
            {
                if (item.GetType().Name == "Button")
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public void Sum(Container ct)
        {
            int sum = 0;

            foreach (object item in ct.list)
            {
                if (item.GetType().BaseType.Name == "ControlElement")
                {
                    sum++;
                }
            }

            Console.WriteLine($"Количество элементов на UI = {sum}");
        }

        public void TotalSquare(Container ct)
        {
            double sum = 0;

            foreach (object item in ct.list)
            {
                if (item.GetType().BaseType.Name == "GeometricFigure")
                {
                    sum += ((GeometricFigure)item).square;
                }
            }

            Console.WriteLine($"Найти площадь занимаемую всеми элментами = {sum}");
        }
    }
}
