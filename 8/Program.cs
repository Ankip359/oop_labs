using System;
using System.Collections.Generic;

namespace Лаба_8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<Circle> cl1 = new CollectionType<Circle>();
                CollectionType<SomeClass> cl2 = new CollectionType<SomeClass>();
                Circle cr1 = new Circle(2);
                Circle cr2 = new Circle(4);
                Circle cr3 = new Circle(5);
                Circle cr4 = new Circle(10);
                List<Circle> ls1 = new List<Circle>() { cr1, cr2, cr3 };

                cl1.Collection = ls1;
                cl1.Show();
                cl1.Add(cr4);
                cl1.Delete(cr1);
                Console.WriteLine("-------------------------");
                cl1.Show();

                SomeClass sc1 = new SomeClass("qwe");
                SomeClass sc2 = new SomeClass("rty");
                SomeClass sc3 = new SomeClass("uio");
                SomeClass sc4 = new SomeClass("p[]");
                List<SomeClass> ls2 = new List<SomeClass> { sc1, sc2, sc3 };

                cl2.Collection = ls2;
                cl2.Show();
                cl2.Add(sc4);
                cl2.Delete(sc2);
                Console.WriteLine("-------------------------");
                cl2.Show();

                Save<Circle>.WriteToFile(cl1.Collection);
                Save<Circle>.ReadFromFile();

                //List<int> a = new List<int> { 1, 2, 3 };
                //Save<int>.WriteToFile(a);
                //Save<int>.ReadFromFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("FINALLY");
            }
        }
    }
}
