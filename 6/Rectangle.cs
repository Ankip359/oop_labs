using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    class Rectangle : GeometricFigure, IGeometricFigure
    {
        public struct Sides
        {
            public double sideA;
            public double sideB;
        }

        public Sides sides;
        public Rectangle(string color, int sideA, int sideB) : base(color)
        {
            sides.sideA = sideA;
            sides.sideB = sideB;
            square = countSquare();
            perimeter = countPerimeter();
        }

        public double countSquare()
        {
            return sides.sideA * sides.sideB;
        }

        public double countPerimeter()
        {
            return (sides.sideA + sides.sideB) * 2;
        }

        public override string ToString()
        {
            return "Тип объекта: " + base.ToString() + $", цвет: {color}, сторона А: {sides.sideA}, сторона В: {sides.sideB}, периметр: {perimeter}, площадь: {square}";
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
