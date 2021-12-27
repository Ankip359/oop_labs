using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Лаба_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int? aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");

            for (int i = 1; i < 7; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 1:
                            Rectangle re = new Rectangle("чёрный", -2, 6);
                            break;

                        case 2:
                            Circle cr = new Circle("чёрный", -5);
                            break;

                        case 3:
                            Radiobutton rb = new Radiobutton(-15, false);
                            break;

                        case 4:
                            Circle cr2 = new Circle("", 5);
                            break;

                        case 5:
                            int a = 0;
                            int b = 20 / a;
                            break;

                        case 6:
                            int[] arr = new int[2] { 0, 2 };
                            int q = arr[2];
                            break;
                    }
                }
                catch (GFException ex)
                {
                    Console.WriteLine(ex.Message);
                   // throw;
                }
                catch (CEException ex)
                {
                    Console.WriteLine(ex.Message);
                }/*
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }*/
                catch
                {
                    Console.WriteLine($"Универсальный catch");
                }
                finally
                {
                    Console.WriteLine($"Это сообщение из блока finnaly");
                    Console.WriteLine("-------------------------------");
                }
            }
        }
    }

    internal sealed partial class Circle : GeometricFigure, IGeometricFigure
    {
        public override string ToString()
        {
            return "Тип объекта: " + base.ToString() + $", цвет: {color}, радиус: {radius}, периметр: {perimeter}, площадь: {square}";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType() && ((Circle)obj).color == color && ((Circle)obj).radius == radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hash = 269;
            hash *= (radius % 2 == 0) ? 24 : 99;
            hash = (hash * 47) + radius;
            return hash;
        }
    }
}
