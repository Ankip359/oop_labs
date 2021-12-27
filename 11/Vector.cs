using System;
using System.Collections;
using System.Linq;

namespace laba11
{
    public class Vector
    {
        public static int ObjCount;
        private int[] array;
        public int[] Array
        {
            get
            {
                return array;
            }
            set
            {
                array = value;
            }
        }

        private int length;
        public int Length
        {
            get
            {
                return length;
            }
            set{}            
        }

        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }            
        }
        private readonly string id;
        private const int weight = 23;
        private string type = "Vector";
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public Vector(int length)
        {
            ObjCount++;
            this.Array = new int[length];
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[Length] = random.Next() % 100;
                this.length++;
            }
            id = array.ToString();
        }
        public Vector()
        {
            ObjCount++;
            
            length = 0;
            array = new int[]{};
            state = "";
            id = array.ToString();
        }
        public Vector(int[] array, int length, string state)
        {
            ObjCount++;
            this.array = array;
            this.length = length;
            this.state = state;
            id = array.ToString();
        }
        public Vector(int[] array = null, int length = 0)
        {
            ObjCount++;
            if (array == null)
            {
                this.Array = new int[length];
                var random = new Random();
                for (int i = 0; i < length; i++)
                {
                    array[Length] = random.Next() % 100;
                    this.length++;
                }
                id = array.ToString();
            }
            else
            {
                id = array.ToString();
                this.array = array;
                this.length = length;
            }
        }
        static Vector()
        {
        }

        public static string GetObjInf()
        {
            return $"Objects count = {ObjCount}";
        }
        
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (value > int.MaxValue || value < int.MinValue)
                    state = "Некорректное значение";
                else
                {
                    array[index] = value;
                    ++this.length;
                }
            }
        }
            
        public static Vector operator +(Vector v1, int v2)
        {
            int[] newArr = new int[v1.array.Length];
            int i = 0;
            foreach (var val in v1.array)
            {
                newArr[i] = val+v2;
                ++i;
            }
            return new Vector(newArr);
        }
        
        public static Vector operator *(Vector v1, int v2)
        {
            int[] newArr = new int[v1.array.Length];
            int i = 0;
            foreach (var val in v1.array)
            {
                newArr[i] = val*v2;
                ++i;
            }
            return new Vector(newArr);
        }

        public override string ToString()
        {
            string arrStr = "";
            for(int i = 0; i < Array.Length; i++)
            {
                arrStr += Array[i].ToString();
                if (i < Array.Length - 1)
                    arrStr += ",";
            }

            return arrStr;
        }

        public override int GetHashCode()
        {
            return this.Array.Sum();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            if (this.ToString() != obj.ToString()) return false;
            
            return true;
        }
    }
}