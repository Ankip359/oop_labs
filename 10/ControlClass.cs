using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Лаба_10
{
    class ControlClass<T> : IDictionary
    {
        List<T> list = new List<T>();
        private int _count;

        public void Add(object key, object value)
        {
            list.Add((T)value);
            _count++;
        }

        public void Remove(object value)
        {
            list.Remove((T)value);
            _count--;
        }
        
        public void RemoveAt(int value)
        {
            list.RemoveAt(value);
            _count--;
        }

        public bool Contains(object value)
        {
            return list.Contains((T)value);
        }

        public void Print()
        {
            foreach (T item in list)
            {
                Console.WriteLine($"Элемент: {item.ToString()}");
            }
        }

        public T Value(int index)
        {
            return list[index];
        }

        public void Clear()
        {
            list.Clear();
            _count = 0;
        }

        public void AddRange(T[] arr)
        {
            list.AddRange(arr);
            _count += arr.Length;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public ICollection Keys => throw new NotImplementedException();

        public ICollection Values => throw new NotImplementedException();

        public int Count 
        { 
            get
            {
                return _count;
            }

            set
            {
                _count = 0;
            }
        }

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();
    }
}
