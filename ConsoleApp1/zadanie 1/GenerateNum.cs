using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.zadanie_1
{
    internal class GenerateNum
    {
        public void GenerateNumber()
        {
            Random liczba = new Random();
           
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(liczba.Next(0, 101));
            }

        }    
    }
}
