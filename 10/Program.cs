using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Лаба_10
{
    class Program
    {
        static void Main(string[] args)
        {
            { // 1
                ControlClass<Book> collection = new ControlClass<Book>();
                Book bk1 = new Book("Буратино");
                Book bk2 = new Book("Колобок");
                Book bk3 = new Book("Золотая рыбка");

                collection.Add(0, bk1);
                collection.Add(0, bk2);
                collection.Add(0, bk3);
                collection.Print();
                Console.WriteLine("-----------------------------");
                collection.Remove(bk2);
                collection.Print();
                Console.WriteLine($"Элемент {bk1.name} содержится в collection: {collection.Contains(bk1)}");
                Console.WriteLine($"Элемент {bk2.name} содержится в collection: {collection.Contains(bk2)}");
            }

            { // 2
                ControlClass<int> collection2 = new ControlClass<int>();
                collection2.Add(0, 2);
                collection2.Add(0, 6);
                collection2.Add(0, 11);
                collection2.Add(0, 1);
                collection2.Add(0, 121);
                collection2.Print();

                Console.Write("Введите n: ");
                string str;
                str = Console.ReadLine();
                int n = Convert.ToInt32(str);
                while (n > 0)
                {
                    collection2.RemoveAt(--n);
                }
                Console.WriteLine("------------------------------------");
                collection2.Print();

                int[] arr = { 1, 2, 3 };

                Console.WriteLine("------------------------------------");
                collection2.AddRange(arr);
                collection2.Print();

                LinkedList<int> link = new LinkedList<int>();

                for (int i = 0; i < collection2.Count; i++)
                {
                    link.AddLast(collection2.Value(i));
                }

                int a = 121;

                foreach (int item in link)
                {
                    if (item == a)
                    {
                        Console.WriteLine("Элемент найден");
                    }
                }

                var collection3 = new ObservableCollection<Book>();
                Book bk1 = new Book("Буратино");

                collection3.CollectionChanged += CollectionChanged;
                collection3.Add(bk1);
                collection3.Remove(bk1);
            }
        }

        private static void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен новый объект");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удален объект");
                    break;
            }
        }
    }
}
