using System;

namespace Лаба_9
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj1 = new MyClass(10, 33, 55);
            MyClass obj2 = new MyClass(1, 323, 7);
            MyClass obj3 = new MyClass(23, 1234, 987);
            ClassEvent CE = new ClassEvent();

            obj1.resize += CE.DoResize;
            obj1.coord += CE.DoCoordinates;
            obj2.resize += CE.DoResize;

            obj1.Action(12, 13, 14);
            Console.WriteLine("----------------------------------------");
            obj2.Action(2, 2, 2);
            Console.WriteLine("----------------------------------------");
            obj3.Action(11, 11, 11);

            string str = "Т! е, к      .с -т";
            Func<string, string> A;

            Console.WriteLine("--------------Работа со строками--------------");
            A = Str.RemoveS;
            Console.WriteLine($"Строка до: {str}\nПосле: {A(str)}\n");
            A = Str.RemoveSpase;
            Console.WriteLine($"Строка до: {str}\nПосле: {A(str)}\n");
            A = Str.Upper;
            Console.WriteLine($"Строка до: {str}\nПосле: {A(str)}\n");
            A = Str.Letter;
            Console.WriteLine($"Строка до: {str}\nПосле: {A(str)}\n");
            A = Str.AddToString;
            Console.WriteLine($"Строка до: {str}\nПосле: {A(str)}\n");
        }
    }
}
