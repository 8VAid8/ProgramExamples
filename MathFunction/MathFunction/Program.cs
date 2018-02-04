using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x!");
            double x;// = 0.31;
            if (double.TryParse(Console.ReadLine(), out x))
            {
                double A = Math.Sqrt(Math.Log(4.0 / 3.0 + x) + 9.0 / 7.0) -
                    Math.Pow(Math.E, (-Math.Sin(1.3 * x - 0.7)));
                Console.WriteLine(A);
            }
            else
                Console.WriteLine("Введено неверное значение! Введите число, " +
                    "используя в качестве разделителя точку!");
            Console.ReadKey();
        }
    }
}
