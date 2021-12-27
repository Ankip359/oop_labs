using System;

namespace laba12
{
    public abstract class Movie
    {
        public static float Rating { get; set; }
        protected static int AgeLimit { get; set; }

        public static void IncrementAgeLimit(int val)
        {
            --AgeLimit;
        }

        public static void isGood()
        {
        }
    }
    
    public  class MyClass { }
    internal class Program
    {
        public static string Vdsd;

        public static int Math(string v, string b)
        {
            return Convert.ToInt32(v) + Convert.ToInt32(b);
        }
        public static void Main(string[] args)
        {
            Reflector.ReleaseName("Program");
            Reflector.GetPublicConstructor("Program");
            Reflector.GetPublicMethods("Program");
            Reflector.GetPropsAndFields("Program");
            Reflector.MethodsWithParam("Program", "val");
            Reflector.InvokeWithParams("Program", "Math");
            
            Reflector.ReleaseName("Movie");
            Reflector.GetPublicConstructor("Movie");
            Reflector.GetPublicMethods("Movie");
            Reflector.GetPropsAndFields("Movie");
            Reflector.MethodsWithParam("Movie", "val");

            var val = Reflector.CreateObj("MyClass");
            Console.WriteLine(val.ToString());
        }
    }
}