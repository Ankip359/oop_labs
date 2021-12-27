using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace laba12
{
    public static class Reflector
    {
        public static string path = @"C:\Users\Egor\RiderProjects\laba12\laba12\log.txt";
        public static void LogFileWrite(string data)
        {
            var writer = new StreamWriter(path, true);
            writer.WriteLine(data);
            writer.Close();
        }
        public static Type GetTypeObj(string ObjName)
        {
            return Type.GetType("laba12." + ObjName, false, true);
        }
        
        
        public static void ReleaseName(string ObjName)
        {
            var type = GetTypeObj(ObjName);
            LogFileWrite(type.Module.Name);
        }

        public static void GetPublicConstructor(string ObjName)
        {
            var type = GetTypeObj(ObjName);
            bool flag = false;
            var constructors = type.GetConstructors(BindingFlags.Public);
            if (constructors.Length == 0) return;
            
            LogFileWrite($"Class {ObjName} has public constructor");
        }

        public static IEnumerable<string> GetPublicMethods(string ObjName)
        {
            var type = GetTypeObj(ObjName);
            List<string> methods = new List<string>();
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                    methods.Add(method.Name);
                    LogFileWrite($"Public method of class {ObjName} - {method.Name}");
            }

            return methods;
        }

        public static IEnumerable<string> GetPropsAndFields(string ObjName)
        {
            var type = GetTypeObj(ObjName);

            var res = new List<string>();
            foreach (var val in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                LogFileWrite($"Public field of class {ObjName} - {val.Name}");
                res.Add(val.Name);
            }
            foreach (var val in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                LogFileWrite($"Public prop of class {ObjName} - {val.Name}");
                res.Add(val.Name);
            }

            return res;
        }

        public static void MethodsWithParam(string ObjName, string propName)
        {
            var type = GetTypeObj(ObjName);
            var list = new List<MethodInfo>();
            foreach (var method in type.GetMethods())
            {
                foreach (var param in method.GetParameters())
                {
                    if(param.Name == propName)
                        list.Add(method);
                }
            }
            foreach (var method in list)
            {
                LogFileWrite($"Method with param {propName} - {method.Name}");
            }
        }

        public static void InvokeWithParams(string ObjName, string methodName)
        {
            var type = GetTypeObj(ObjName);
            var method = type.GetMethod(methodName);
            
            var reader = new StreamReader(@"C:\Users\Egor\RiderProjects\laba12\laba12\propsFroInvoke.txt");
            string data = reader.ReadLine();
            reader.Close();
            string[] args = data.Split(' ');
            
            Console.WriteLine(method.Invoke(Activator.CreateInstance(type), args));
        }

        public static object CreateObj(string ObjName)
        {
            var type = GetTypeObj(ObjName);
            return Activator.CreateInstance(type);
        }
    }
}