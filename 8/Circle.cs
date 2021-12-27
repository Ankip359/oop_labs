using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_8
{
    class Circle
    {
        public double radius;
        private double square;
        private double perimeter;
        public double Radius
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

        public Circle(double radius)
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

        public override string ToString()
        {
            return "Тип объекта: " + base.ToString() + $", радиус: {radius}, периметр: {perimeter}, площадь: {square}";
        }
    }
}
