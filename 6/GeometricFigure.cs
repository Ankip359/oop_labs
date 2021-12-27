using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    abstract class GeometricFigure
    {
        public double perimeter;
        public double square { get; protected set; }
        public string color;

        public GeometricFigure(string color)
        {
            this.color = color;
        }

        public abstract void printblabla();
    }
}
