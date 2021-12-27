using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace laba11
{
    internal class Program
    {
        public static int WriteCountl = 0;
        public static void PrintSelected(IEnumerable selected)
        {
            WriteCountl++;
            Console.WriteLine($"{WriteCountl}----------------\n");
            foreach (var el in selected)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            var arr1 = new[]
            {
                "январь",
                "февраль",
                "март",
                "апрель",
                "май",
                "июнь",
                "июль",
                "август",
                "сенятбрь",
                "октябрь",
                "ноябрь",
                "декабрь"
            };

            var selected1 = from s in arr1
                where s.Length == 6
                select s;
            
            PrintSelected(selected1);
            
            var selected2 = from s in arr1
                where s == "июнь" || s == "июль" || s == "август" || s == "декабрь" || s == "январь" || s == "февраль"
                select s;

            PrintSelected(selected2);

            var selected3 = from s in arr1
                orderby s
                select s;
            PrintSelected(selected3);
            
            var selected4 = from s in arr1
                where s.Contains('ю') && s.Length >= 4
                select s;
            PrintSelected(selected4);
            
            var list1 = new List<Vector>
            {
                new Vector(new[]{1,2,4}),
                new Vector(new[]{4,4}),
                new Vector(new[]{9,4,0}),
                new Vector(new[]{22,45,4}),
                new Vector(new[]{1,2,567}),
                new Vector(new[]{1,-4,0,323,49}),
                new Vector(new[]{4}),
                new Vector(new[]{45,-5,4}),
                new Vector(new[]{0,4}),
                new Vector(new[]{4,5,98,-2})
            };
            var list2 = new List<Vector>
            {
                new Vector(new[]{3,5,7,4}),
                new Vector(new[]{14,-4}),
                new Vector(new[]{9,-4,0}),
                new Vector(new[]{-2,-9,0}),
                new Vector(new[]{23,0,67})
            };
            var selected5 = list1.Where(val => val.Array.Contains(0));
            PrintSelected(selected5);
            
            var selected6 = from vector in list1
                let val = vector.Array.Sum()
                orderby val select val;
            PrintSelected(selected6);
            
            var selected7 = from vector in list1
                let lenght = vector.Array.Length
                where lenght == 3 || lenght == 5 || lenght == 7
                    select vector;
            PrintSelected(selected7);

            var selected8 = list1.OrderByDescending(vect => vect.Array.Sum()).Select(vect => vect).First();
            PrintSelected(new []{selected8});

            var selected9 = list1.Find(val => val.Array.Any(num => num < 0));
            PrintSelected(new []{selected9});
            
            var selected10 = list1.OrderBy(vect => vect.Array.Length);
            PrintSelected(selected10);

            var selected11 = from vect in list1
                let sum = vect.Array.Sum()
                where sum > 70 
                orderby sum
                group vect by vect.Length into vectG
                select new {
                    vect = vectG,
                    vectG.Key
                };
            PrintSelected(selected11);

            var selected12 = from vect1 in list1
                join vect2 in list2 on vect1.Type equals vect2.Type
                select new
                {
                    vect1,
                    vect2
                };
            PrintSelected(selected12);
        }
    }
}