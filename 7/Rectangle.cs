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
            public double SideA 
            {
                get
                {
                    return sideA;
                }
                set
                {
                    if (value <= 0) throw new GFException("неверная длина геометрической фигуры", GetType().FullName);
                    sideA = value;
                }
            }

            public double sideB;
            public double SideB
            {
                get
                {
                    return sideB;
                }
                set
                {
                    if (value <= 0) throw new GFException("неверная длина геометрической фигуры", GetType().FullName);
                    sideB = value;
                }
            }
        }

        public Sides sides;
        public Rectangle(string color, int sideA, int sideB) : base(color)
        {
            sides.SideA = sideA;
            sides.SideB = sideB;
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
