using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Globalization; - для конвертации с точкой

namespace Лаба_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b1 = true;
            byte bt1 = 250;
            sbyte bt2 = -120;
            char ch1 = '7';
            short s1 = -30000;
            ushort s2 = 65000;
            int i1 = -2_000_000_000;
            uint i2 = 4200_000_000;
            long l1 = -9_000_000_000_000_000_000;
            ulong l2 = 18_000_000_000_000_000_000;
            float f1 = 32.32f;
            double d1 = 12.312;
            decimal dc1 = 1.312321m;

            string str;
            object o;

            Console.Write("Bool: ");
            str = Console.ReadLine();
            b1 = Convert.ToBoolean(Convert.ToInt32(str));
            Console.WriteLine($"Bool = {b1}");

            Console.Write("Char: ");
            str = Console.ReadLine();
            ch1 = Convert.ToChar(str);
            Console.WriteLine($"Char = {ch1}");

            Console.Write("Decimal: ");
            str = Console.ReadLine();
            dc1 = Convert.ToDecimal(str);
            Console.WriteLine($"Decimal = {dc1}");

            // NumberFormatInfo numberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." }; - для конвертации числе с плавающей точкой(в строке ставится .  а не ,)
            // double a = Conver.ToDouble(str, numberFormatInfo);

            l1 = i1;
            i2 = bt1;
            d1 = f1;
            i1 = bt2;
            s2 = bt1;

            d1 = (double)dc1;
            f1 = (float)d1;
            bt1 = (byte)i1;
            s2 = (ushort)i1; //преведение 
            i1 = (int)bt1;

            o = i1;
            i1 = (int)o;
            o = d1;
            d1 = (double)o;

            var value = "a";
            //value = 3;
            Console.WriteLine($"Var = {value}");

            int? x1 = null;
            int? x2 = null;
            Console.WriteLine($"Сравнение nullable = {x1 == x2}");

            string a = "aq";
            string a2 = "aq";
            string b = "b";
            Console.WriteLine($"Сравнение a и b = {a == b}");
            Console.WriteLine($"Сравнение a и a2 = {a == a2}");

            string str1 = "Первая строка";
            string str2 = "Вторая строка";
            string str3;
            string[] str4;
            Console.WriteLine($"Сцепление str1 & str2 = {String.Concat(str1, str2)}");
            str3 = String.Copy(str1);
            Console.WriteLine($"str3(скопированная из str1) = {str3}");
            str2 = str1.Substring(4);
            Console.WriteLine($"str2(выделенная подстрока из str1) = {str2}");
            str4 = str1.Split();
            for (int i = 0; i < str4.Length; i++)
            {
                Console.WriteLine(str4[i]);
            }
            Console.WriteLine($"str3(вставки подстроки в заданную позицию) = {str3.Insert(5, str1)}");
            Console.WriteLine($"str3(удаление заданной подстроки) = {str3.Remove(5)}");

            string str5 = "";
            string str6 = null;
            Console.WriteLine($"str5(проверка IsNullOrEmpty) = {string.IsNullOrEmpty(str5)}");
            Console.WriteLine($"str6(проверка IsNullOrEmpty) = {string.IsNullOrEmpty(str6)}");
            Console.WriteLine($"str5 == str6 {str5 == str6}");
            Console.WriteLine($"str5(сцепление c str6) {String.Concat(str5, str6)}");

            StringBuilder sb = new StringBuilder("bcd", 5);
            sb.Append("e");
            sb.Insert(0, "a");
            sb.Remove(2, 2);
            Console.WriteLine($"StringBuilder: {sb}");

            int[,] arr = new int[3, 4];
            int arrLength0 = arr.GetLength(0);
            int arrLength1 = arr.GetLength(1);
            for (int i = 0; i < arrLength0; i++)
            {
                for (int j = 0; j < arrLength1; j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.WriteLine();
            }

            string[] arr_str = { "first", "second", "third" };
            foreach (var item in arr_str)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"Длинна массива строк = {arr_str.Length}");
            Console.Write($"Какой элемент изменить?(отсчёт с 0)(Введите) ");
            str = Console.ReadLine();
            i1 = Convert.ToInt32(str);
            Console.Write($"На что заменить?\n(Введите) ");
            str = Console.ReadLine();
            arr_str[i1] = str;
            foreach (var item in arr_str)
            {
                Console.WriteLine($"{item}");
            }

            int[][] jagged = new int[3][];
            jagged[0] = new int[2];
            jagged[1] = new int[3];
            jagged[2] = new int[4];
            int jaggedLength = jagged.Length;
            int jaggedLength2;
            Console.WriteLine("Заполните ступенчатый массив:");
            for (int i = 0; i < jaggedLength; i++)
            {
                jaggedLength2 = jagged[i].Length;
                for (int j = 0; j < jaggedLength2; j++)
                {
                    str = Console.ReadLine();
                    jagged[i][j] = Convert.ToInt32(str);
                }

            }
            for (int i = 0; i < jaggedLength; i++)
            {
                jaggedLength2 = jagged[i].Length;
                for (int j = 0; j < jaggedLength2; j++)
                {
                    Console.Write($"{jagged[i][j]}\t");
                }
                Console.WriteLine();
            }

            var arr_var = new int[4];
            var str_var = "qwe";

            ValueTuple<int, string, char, string, ulong> human = (99, "qwe", 'm', "eww", 12031703);
            ValueTuple<int, string, char, string, ulong> human2 = (99, "qwe", 'm', "eww", 12031703);
            //var human = (first: 99, second: "name");
            //(string name, int age) human = ("qwe", 12);

            Console.WriteLine($"Кортеж: {human}");
            Console.WriteLine($"Первый: {human.Item1}, второй: {human.Item2}, четвёртый: {human.Item4}");
            Console.WriteLine($"Сравнение: {human == human2}");

            int human_int = human.Item1;
            object ob = human.Item2;
            string human_string = (string)ob;

            static (int, int, int, char) Foo(int[] array, string st)
            {
                return (array.Max(), array.Min(), array.Sum(), st[0]);
            }

            int[] arr3 = new int[] { 1, 2, 3, 4, 5 };
            string str11 = "qwe";
            Console.WriteLine(Foo(arr3, str11));

            checked
            {
                int i3 = 2147483647;
                Console.WriteLine(i3);
            }

            unchecked
            {
                int i3 = 2147483647;
                Console.WriteLine(i3);
            }

        }
    }
}
