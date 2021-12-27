using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    class Button : ControlElement, IControl
    {
        public Button(int size) : base(size)
        {
            countClick = 0;
        }
        public int countClick { get; }

        public void ShowInfo()
        {
            Console.WriteLine($"Количество кликов на кнопку: {countClick}");
        }

        public override string ToString()
        {
            return $"Тип объекта: {base.ToString()}, состояние: {status}, размер: {size}, кол-во нажатий: {countClick}";
        }
    }
}
