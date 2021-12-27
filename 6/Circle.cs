using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    internal sealed partial class Circle : GeometricFigure, IGeometricFigure
    {
        public int radius;
        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
                square = countSquare();
                perimeter = countPerimeter();
            }
        }

        public Circle(string color, int radius) : base(color)
        {
            Radius = radius;
        }

        public double countSquare()
        {
            return Math.Round(Math.PI * Math.Pow(radius, 2), 2);
        }

        public double countPerimeter()
        {
            return Math.Round(2 * Math.PI * radius, 2);
        }

        public override void printblabla()
        {
            Console.WriteLine("Метод вызван через абстрактный класс");
        }

        void IGeometricFigure.printblabla()
        {
            Console.WriteLine("Метод вызван через интерфейс");
        }
    }
}
