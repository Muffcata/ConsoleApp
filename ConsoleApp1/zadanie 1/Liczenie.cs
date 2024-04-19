using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.zadanie_1
{
    internal class Liczenie
    {
        public void LiczenieMethod()
        {
            Console.WriteLine("Wprowadź liczbę całkowitą");
            float number = float.Parse(Console.ReadLine());

            if (number > 0)
            {
                Console.WriteLine("To jest liczba dodatnia");
            }
            else if (number < 0)
            {
                Console.WriteLine("To jest liczba ujemna");
            }
            else
                Console.WriteLine("To jest liczba równa zero");
        }
    }
}
