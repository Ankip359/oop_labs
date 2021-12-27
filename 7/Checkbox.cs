using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    class Checkbox : ControlElement, IControl
    {
        public Checkbox(int size, Color color) : base(size)
        {
            this.color = color;
        }

        public enum Color
        {
            чёрный,
            белый,
            красный,
            синий,
            розовый,
            фиолетовый
        };

        public Color color;
        public override void Resize(int addition)
        {
            size += addition;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Цвет фона checkbox: {color}");
        }

        public override string ToString()
        {
            return $"Тип объекта: {base.ToString()}, состояние: {status}, размер: {size}, цвет: {color}";
        }
    }
}
