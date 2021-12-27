using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Лаба_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Airline o1 = new Airline();
            Airline o2 = new Airline("Минск", 444, "Boieng");

            int a = 10;
            int b = 22;
            o1.ChangeVariable(ref a, out b);
            Console.WriteLine($"a = {a}, b = {b}");
            Airline.Info();
            Console.WriteLine($"Сумма полей partial класса равна {PartClass.varsum()}");
            o2.printHashCode();

            ForEqualation std1 = new ForEqualation("Ivan", 22);
            ForEqualation std2 = new ForEqualation("Ivan", 22);
            ForEqualation std3 = new ForEqualation("Ivan", 46);

            Console.WriteLine($"Std1 и std2 равны: {std1.Equals(std2)}");
            Console.WriteLine($"Std1 и std3 равны: {std1.Equals(std3)}");
            Console.WriteLine($"Hashcode std1: {std1.GetHashCode()}, std2: {std2.GetHashCode()}, std3: {std3.GetHashCode()}");
            Console.WriteLine(std1.ToString());

            Airline[] array = new Airline[2];
            string[] arr1 = new string[] {"Понедельник", "Среда", "Четверг" };
            string[] arr2 = new string[] { "Вторник", "Среда", "Четверг" };
            array[0] = new Airline("Гродно", 666, "Boieng", arr1, 1200);
            array[1] = new Airline("Минск", 999, "Airbus", arr2, 1730);
            string str;

            Console.Write("Введите пункт назначения: ");
            str = Console.ReadLine();
            Console.WriteLine("Рейсы: ");
            for (int i = 0; i < array.Length; i++)
            {
                if (str == array[i].destination)
                {
                    Console.WriteLine($"{array[i].flightNum}");
                }
            }

            Console.Write("Введите день недели: ");
            str = Console.ReadLine();
            Console.WriteLine("Рейсы: ");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].days.Length; j++)
                {
                    if (str == array[i].days[j])
                    {
                        Console.WriteLine($"{array[i].flightNum}");
                    }
                }
            }

            var user = new { Name = "Tom", Age = 34 };
            var student = new { Name = "Alice", Age = 21 };
            var manager = new { Name = "Bob", Age = 26, Company = "Microsoft" };

            Console.WriteLine(user.GetType().Name); // <>f__AnonymousType0'2
            Console.WriteLine(student.GetType().Name); // <>f__AnonymousType0'2
            Console.WriteLine(manager.GetType().Name); // <>f__AnonymousType1'3
        }
    }

    class Airline
    {
        public string destination { get; set; }                         // пункт назначения
        public int flightNum { get; set; }
        private string planeType { get; set; }
        public int time;
        public int Time 
        {
            set
            {
                if (value >= 2400)
                {
                    Console.WriteLine("Время введено некорректно");
                }
                else
                {
                    time = value;
                }
            }

            get { return time; } 
        }
        public string[] days { get; set; }
        private readonly int hashCode;
        public const int someValue = 10;
        private static int NumberOfObjects = 0;

        public Airline()
        {
            destination = "Москва";
            flightNum = 1;
            days = new string[] { "Понедельник" };
            planeType = "Airbus";
            time = 1200;
            NumberOfObjects++;
            hashCode = NumberOfObjects * 183012 / 1039;
        }

        public Airline(string dest, int fliNum, string plTp)
        {
            destination = dest;
            flightNum = fliNum;
            planeType = plTp;
            NumberOfObjects++;
            hashCode = NumberOfObjects * 183012 / 1039;
        }

        public Airline(string dest, int fliNum, string plTp, string[] d, int tm = 1300)
        {
            destination = dest;
            flightNum = fliNum;
            planeType = plTp;
            time = tm;
            days = d;
            NumberOfObjects++;
            hashCode = NumberOfObjects * 183012 / 1039;
        }

        static Airline()  //статический конструктор
        {
            Console.WriteLine("Создан первый объект класса");
        }

      /*  private Airline()
        {

        }*/

        public void ChangeVariable(ref int a, out int b)
        {
            b = a;
            a = 111;
        }

        public static void Info()
        {
            Console.WriteLine($"Создано {NumberOfObjects} объектов класса");
        }

        public void printHashCode()
        {
            Console.WriteLine($"Hashcode: {hashCode}");
        }
    }

    public partial class PartClass
    {
        private static int a = 10;
        private static int b = 23;
    }

    public partial class PartClass
    {
        public static int varsum()
        {
            return a + b;
        }
    }

    public class ForEqualation
    {
        string Name;
        int age;

        public ForEqualation(string name, int ag)
        {
            Name = name;
            age = ag;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            ForEqualation person = (ForEqualation)obj;

            return (this.Name == person.Name && this.age == person.age);
        }

        public override int GetHashCode()
        {
            // 269 или 47 простые
            int hash = 269;
            hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            hash = (hash * 47) + age;
            return hash;
        }

        public override string ToString()
        {
            return "Type " + base.ToString() + " " + Name + " " + age;
        }
    }
}
